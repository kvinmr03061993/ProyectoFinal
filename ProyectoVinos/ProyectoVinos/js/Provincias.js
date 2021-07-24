
    $(document).ready(function () {
        $("#enlaceajax").click(function (evento) {
            $.ajax({
                dataType: "json",
                url: "https://ubicaciones.paginasweb.cr/provincias.json",
                data: {},
                success: function (data) {
                    var html = "<select>";
                    for (key in data) {
                        html += "<option value='" + key + "'>" + data[key] + "</option>";
                    }
                    html += "</select";
                    $('#destino').html(html);
                }
            });
        });
     });

