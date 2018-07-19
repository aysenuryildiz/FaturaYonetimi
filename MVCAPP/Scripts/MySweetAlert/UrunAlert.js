$('#UrunKaydet').click(function (e) {
    if ($('#Kategori').val() === "") {
        sweetAlert("Kategori Seçilmedi", "Lütfen Bir Kategori Şeçiniz", "error");
        //alert("File Shouldn't Be Empty!!");
        return false;
    }
    if ($('#UrunAdi').val() === "") {
        sweetAlert("Ürün Adı Boş Olamaz", "Lütfen Bir Ürün Giriniz", "error");
        //alert("File Shouldn't Be Empty!!");
        return false;
    }

    if ($('#UrunAdi').val() !== "" && $('#KategoriID').val() !== "") {
        sweetAlert("Kaydedildi", "", "success");
        return true;
    }
});



