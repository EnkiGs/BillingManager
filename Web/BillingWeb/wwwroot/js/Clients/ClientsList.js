var ClientsList = (function () {

    let self = {};

    self.Init = function () {
        tableClients();
    }

    function tableClients() {
        //Pagination First/Last Numbers
        $('#tableClients').DataTable({
            "pagingType": "first_last_numbers",
            order: [[2, 'asc']],
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

    return self;
})();