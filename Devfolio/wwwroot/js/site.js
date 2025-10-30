$(function () {

    function cargarUsuarios() {
        $("#tablaUsuarios").hide();
        $("#spinner").show();
        $("#tablaUsuarios tbody").empty();

        $.ajax("https://randomuser.me/api?results=10", {
            success(json) {
                for (let user of json.results) {
                    $("#tablaUsuarios tbody").append(`
                            <tr>
                                <td><img src="${user.picture.medium}" class="rounded-circle border" alt="Foto"></td>
                                <td>${user.name.title}</td>
                                <td>${user.name.first} ${user.name.last}</td>
                                <td>${user.phone}</td>
                                <td>${user.dob.age}</td>
                            </tr>
                        `);
                }

                $("#spinner").hide();
                $("#tablaUsuarios").fadeIn(600);
            },
            error() {
                $("#spinner").html("<p class='text-danger'>Error al obtener los datos.</p>");
            }
        });
    }

    // Cargar usuarios al entrar
    cargarUsuarios();

    // Botón de recarga
    $("#btnRecargar").on("click", function () {
        cargarUsuarios();
    });
});