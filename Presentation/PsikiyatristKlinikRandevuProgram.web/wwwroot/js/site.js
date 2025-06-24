function doktorSec(element) {
    var id = element.getAttribute('data-id');
    document.querySelector('input[name="PsikiyatristId"]').value = id;
    document.querySelectorAll('.doktor-kart').forEach(function (card) {
        card.classList.remove('selected');
    });
    element.classList.add('selected');

    $.ajax({
        url: `/Hasta/Randevular/GetAvailableSlots?psikiyatristId=${id}`,
        method: 'GET',
        success: function (slotsByDay) {
            let container = $('#zamanSlotlari');
            container.empty();

            if (Object.keys(slotsByDay).length === 0) {
                container.html('<p class="text-danger">Bu doktor için uygun saat bulunamadı.</p>');
                return;
            }

            let navTabs = `<ul class="nav nav-tabs mb-3" id="gunTabs" role="tablist">`;
            let tabContent = `<div class="tab-content" id="gunTabsContent">`;

            let tabIndex = 0;
            for (const day in slotsByDay) {
                const dayId = `tab-${tabIndex}`;
                const activeClass = tabIndex === 0 ? 'active' : '';
                const showClass = tabIndex === 0 ? 'show active' : '';

                navTabs += `
                    <li class="nav-item" role="presentation">
                        <button class="nav-link ${activeClass}" id="${dayId}-tab" data-bs-toggle="tab" data-bs-target="#${dayId}" type="button" role="tab">
                            ${day}
                        </button>
                    </li>
                `;

                tabContent += `<div class="tab-pane fade ${showClass}" id="${dayId}" role="tabpanel">`;
                tabContent += `<div class="row">`;

                slotsByDay[day].forEach(slot => {
                    tabContent += `
                        <div class="col-md-3 mb-2">
                            <label class="form-check-label w-100">
                                <input type="radio" class="form-check-input" name="TarihSaat" value="${slot.raw}" required />
                                ${slot.label}
                            </label>
                        </div>
                    `;
                });

                tabContent += `</div></div>`;
                tabIndex++;
            }

            navTabs += `</ul>`;
            tabContent += `</div>`;

            container.append(navTabs + tabContent);
        },
        error: function () {
            $('#zamanSlotlari').html('<p class="text-danger">Slotlar yüklenemedi.</p>');
        }
    });
}

// SignalR bağlantısı da buraya taşınabilir (isteğe bağlı)
