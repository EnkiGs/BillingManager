var DocumentList = (function () {

    let self = {};

    self.Init = function () {
        tableDocuments();
        updateTotal();
        document.getElementById('tableDocuments').getElementsByTagName('tbody')[0].addEventListener("DOMSubtreeModified", updateTotal)
    }

    function tableDocuments() {
        //Pagination First/Last Numbers
        $('#tableDocuments').DataTable({
            "pagingType": "first_last_numbers",
            initComplete: function () {
                this.api().columns().every(function () {
                    var column = this;
                    var search = $(`<input class="form-control form-control-sm" type="text" placeholder="Search">`)
                        .appendTo($(column.footer()).empty())
                        .on('change input', function () {
                            var val = $(this).val()

                            column
                                .search(val ? val : '', true, false)
                                .draw();
                            updateTotal()
                        });
                });
            }
        });
    }

    

    function updateTotal() {
        var totals = document.getElementsByClassName('TotalValues')
        var total = 0
        for (var i = 0; i < totals.length; i++) {
            total += parseInt(totals[i].innerText)
        }
        document.getElementById('TotalValue').innerText = total
    }

    return self;
})();