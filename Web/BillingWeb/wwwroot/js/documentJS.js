var documentJS = (function () {
    let self = {};

    self.Init = function () {
        updateInputsListener();
        updateTotal();
        removeButton();
        updateDisplayPayementDate();
    }

    var wrapper = $('.add-wordings');

    $(".btn-add-wording").click(function (e) {
        e.preventDefault();
        var block = $('.add-wording:first-child').clone(true);
        block.appendTo(wrapper);
        var listInputs = block[0].getElementsByClassName("listened");
        for (var i = 0; i < listInputs.length; i++) {
            listInputs[i].value = "0";
        }
        block[0].getElementsByClassName("content")[0].value = "";
        block[0].getElementsByClassName("idWording")[0].value = "0";

        $('.add-wording .btn-remove-wording').show();
        indexing();

        autocomplete(block[0].getElementsByClassName("content")[0], billDetail.regularDescriptions)

        updateInputsListener();
    });

    $('.btn-remove-wording').click(function (e) {
        e.preventDefault();
        if ($('.add-wording').length > 1) {
            $(this).parents('.add-wording').remove();

            removeButton();
            indexing();
            updateTotal();
        }
    });

    document.getElementById("PayementWaySelect").addEventListener("change", function () {
        updateDisplayPayementDate();
    });

    function updateInputsListener() {
        var userSelection = document.getElementsByClassName('listened');

        for (var i = 0; i < userSelection.length; i++) {
            userSelection[i].addEventListener("input", function () {
                $(this).val($(this).val().replace(/\,/g, '.'))
                updateTotal();
            });
        }
    }

    function removeButton() {
        if ($('.add-wording').length == 1) {
            $('.add-wording .btn-remove-wording').hide();
        }
    }

    function indexing() {
        var list = $('.add-wording');
        for (var i = 0; i < list.length; i++) {
            var inputs = list[i].getElementsByClassName("form-control");
            for (var j = 0; j < inputs.length; j++) {
                inputs[j].setAttribute("name", inputs[j].getAttribute("name").replace(/[0-9]/, i));
            }
        }
    }

    function updateTotal() {
        var listened = document.getElementsByClassName('listenedGroup');
        var total = 0.0;
        for (var i = 0; i < listened.length; i++) {
            var quantity = listened[i].getElementsByClassName("quantity")[0].value;
            var price = listened[i].getElementsByClassName("price")[0].value;
            total += parseFloat(quantity * price);
            if (isNaN(total)) {
                total = 0;
                break;
            }
        }
        document.getElementById("TotalInput").value = total.toFixed(2);
    }

    function updateDisplayPayementDate() {
        var select = document.getElementById("PayementWaySelect");
        if (select.selectedIndex == 0) {
            document.getElementById("DatePDiv").style.display = "none";
        }
        else {
            document.getElementById("DatePDiv").style.display = "block";
        }
    }

    return self;
})();