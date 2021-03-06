$('document').ready(function () {
    $("#PhoneNumber").mask("9999-9999");
    $("#ZipCode").mask("99999-999");

    $('#findZipCode').click(function () {
        var method = '/Contact/GetAddress?ZipCode=' + $("#ZipCode").val();

        $.getJSON(method, function (data) {
            $(data).each(function () {
                var Street = (this.Street != "" || this.Street != undefined) ? this.Street : "";
                Street = (this.ShortStreet != "" || this.ShortStreet != undefined) ? this.ShortStreet : "";
                var Neighborhood = (this.Neighbourhood != "" || this.Neighbourhood != undefined) ? this.Neighbourhood : "";
                var City = (this.City != "" || this.City != undefined) ? this.City : "";
                var State = (this.State != "" || this.State != undefined) ? this.State : "";

                $("#Address").val(Street);
                $("#Neighborhood").val(Neighborhood);
                $("#City").val(City);
                $("#State").val(State);
            });
        });

    });
});