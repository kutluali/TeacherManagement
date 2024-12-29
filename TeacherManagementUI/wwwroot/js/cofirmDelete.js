function confirmDelete(url, successCallback) {
    Swal.fire({
        title: 'Bu öğeyi silmek istediğinize emin misiniz?',
        text: "Bu işlem geri alınamaz!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Sil',
        cancelButtonText: 'İptal'
    }).then((result) => {
        if (result.isConfirmed) {
            const tokenElement = document.querySelector('input[name="__RequestVerificationToken"]');
            const token = tokenElement ? tokenElement.value : null;

            fetch(url, {
                method: 'POST', // DELETE yerine POST kullanıyorsunuz
                headers: {
                    'Content-Type': 'application/json',
                    'RequestVerificationToken': token
                }
            })
                .then(response => {
                    if (response.ok) {
                        Swal.fire(
                            'Silindi!',
                            'Öğe başarıyla silindi.',
                            'success'
                        ).then(() => {
                            if (successCallback) successCallback();
                        });
                    } else {
                        Swal.fire(
                            'Hata!',
                            'Silme işlemi sırasında bir hata oluştu.',
                            'error'
                        );
                    }
                })
                .catch(error => {
                    Swal.fire(
                        'Hata!',
                        'Bir hata oluştu: ' + error.message,
                        'error'
                    );
                });
        }
    });
}
