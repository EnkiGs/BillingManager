var DocumentList = (function () {

    let self = {};

    self.Init = function () {
        tableDocuments();
        updateTotal();
        document.getElementById('tableDocuments').getElementsByTagName('tbody')[0].addEventListener("DOMSubtreeModified", updateTotal);
        resize();
    }

    function tableDocuments() {
        //Pagination First/Last Numbers
        $('#tableDocuments').DataTable({
            "pagingType": "first_last_numbers",
            responsive: true,
            columnDefs: [
                { responsivePriority: 1, targets: [0, 3, -1] },
                { responsivePriority: 2, targets: '_all' },
                { "type": "ref", "targets": 0 } //,
                //{ orderable: true, targets: 0 }
            ],
            order: [[0, 'desc']],
            initComplete: function () {
                this.api().columns(".searchable").every(function () {
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

    jQuery.fn.dataTableExt.oSort["ref-asc"] = function (x, y) {
        let yearX = parseInt(x.substring(x.search("-")+1));
        let yearY = parseInt(y.substring(y.search("-")+1));
        let numX = parseInt(x.substring(0, x.search("-")));
        let numY = parseInt(y.substring(0, y.search("-")));
        return yearX == yearY ? (numX < numY ? -1 : (numX > numY ? 1 : 0)) : (yearX < yearY ? -1 : (yearX > yearY ? 1 : 0));
    };

    jQuery.fn.dataTableExt.oSort["ref-desc"] = function (x, y) {
        let yearX = parseInt(x.substring(x.search("-") + 1));
        let yearY = parseInt(y.substring(y.search("-") + 1));
        let numX = parseInt(x.substring(0, x.search("-")));
        let numY = parseInt(y.substring(0, y.search("-")));
        return yearX == yearY ? (numX < numY ? 1 : (numX > numY ? -1 : 0)) : (yearX < yearY ? 1 : (yearX > yearY ? -1 : 0));
    }

    function resize() {
        if ($('tfoot').css('display') == 'none') {
            $('tbody tr td:last-child > a:nth-child(2n)').each((i, elem) => $('<br/>').insertAfter($(elem)));
        }
    }

    function updateTotal() {
        var totals = document.getElementsByClassName('TotalValues')
        var total = 0.0
        for (var i = 0; i < totals.length; i++) {
            total += parseFloat(totals[i].innerText.replace(/,/g, '.'))
        }
        document.getElementById('TotalValue').innerText = total
    }

    return self;
})();