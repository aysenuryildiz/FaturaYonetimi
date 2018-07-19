
{
    //Add Multiple Order.
    $("#addToList").click(function (e) {
        e.preventDefault();

        if ($.trim($("#UrunID").val()) == "" || $.trim($("#Miktar").val()) == "" || $.trim($("#BirimFiyat").val()) == "" || $.trim($("#KdvMiktar").val()) == "") return;

        var UrunID = $("#UrunID").val(),
            Miktar = $("#Miktar").val(),
            BirimFiyat = $("#BirimFiyat").val(),
            KdvMiktar = $("#KdvMiktar").val(),
            detailsTableBody = $("#detailsTable tbody");

        var productItem = '<tr><td>' + UrunID + '</td><td>' + Miktar + '</td><td>' + BirimFiyat + '</td><td>' + KdvMiktar + '</td><td><a data-itemId="0" href="#" class="deleteItem">SİL</a></td></tr>';
        detailsTableBody.append(productItem);
        clearItem();
    });
    //After Add A New Order In The List, Clear Clean The Form For Add More Order.
    function clearItem() {
        $("#UrunID").val('');

        $("#Miktar").val('');
        $("#BirimFiyat").val('');
        $("#KdvMiktar").val('');
    }
    // After Add A New Order In The List, If You Want, You Can Remove It.
    $(document).on('click', 'a.deleteItem', function (e) {
        e.preventDefault();
        var $self = $(this);
        if ($(this).attr('data-itemId') == "0") {
            $(this).parents('tr').css("background-color", "#ff6347").fadeOut(800, function () {
                $(this).remove();
            });
        }
    });





    //After Click Save Button Pass All Data View To Controller For Save Database
    function saveOrder(data) {
        return $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: "/Fatura/SaveOrder",
            data: data,
            success: function (result) {
                sweetAlert({
                    title: "Kaydedildi!",
                    type: "success"
                }, function () {
                    window.location.href = '/Fatura/FaturaListele';
                });

            },
            error: function () {
                //alert("Error!")
                swal("Oops", "Eksik Alanları Doldurun", "error");

            }
        });
    }







    $("#saveOrder").click(function (e) {
        e.preventDefault();

        var orderArr = [];
        orderArr.length = 0;

        $.each($("#detailsTable tbody tr"), function () {
            orderArr.push({
                UrunID: $(this).find('td:eq(0)').html(),
                Miktar: $(this).find('td:eq(1)').html(),
                BirimFiyat: $(this).find('td:eq(2)').html(),

                KdvMiktar: $(this).find('td:eq(3)').html()
            });
        });

        var data = JSON.stringify({
            MusteriD: $("#MusteriD").val(),
            SaticiID: $("#SaticiID").val(),
            FaturaTip: $("#FaturaTip").val(),
            FaturaTarihi: $("#FaturaTarihi").val(),
            order: orderArr
        });



        $.when(saveOrder(data)).then(function (response) {
            console.log(response);
        });
    });

}