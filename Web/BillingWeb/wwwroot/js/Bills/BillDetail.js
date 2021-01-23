var billDetail = (function () {
    let self = {};

    self.Init = function () {
        loadRegularStrings();
    }


    var regularObjects = null;
    var regularDescriptions = null;

    function loadRegularStrings() {
        $.ajax({
            type: "GET",
            url: '/Bills/GetRegularObjects',
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (listObjects) {
                regularObjects = listObjects;
                autocomplete(document.getElementById("Bill_Objet"), regularObjects);
            },
            error: function (e) {
                alert("ERREUR REGULAR OBJECTS");
            }
        });
        $.ajax({
            type: "GET",
            url: '/Bills/GetRegularDescriptions',
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (listDescriptions) {
                regularDescriptions = listDescriptions;
                var listContents = document.getElementsByClassName("content");
                for (var i = 0; i < listContents.length; i++) {
                    autocomplete(listContents[i], regularDescriptions);
                }
            },
            error: function (e) {
                alert("ERREUR REGULAR DESCRIPTIONS");
            }
        });
    }

    return self;
})();