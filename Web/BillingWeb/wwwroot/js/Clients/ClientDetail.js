var ClientsDetail = (function () {

    let self = {};

    self.Init = function () {
        $('#submitButton').click(CheckValidClient); 
    }

    function CheckValidClient() {
        var societe = $('#client_Societe').val();
        var nom = $('#client_Nom').val();
        var civil = $('#client_Civil').val();
        if (societe == "" && civil == 0) {
            $('#notValidSociete').removeClass("d-none");
            $('#notValidName').addClass("d-none");
        }
        else if (nom == "" && civil != 0) {
            $('#notValidSociete').addClass("d-none");
            $('#notValidName').removeClass("d-none");
        }
        else {
            $('#notValidSociete').addClass("d-none");
            $('#notValidName').addClass("d-none");
            $('#SubmitClient').submit();
        }
    } 

    return self;
})();