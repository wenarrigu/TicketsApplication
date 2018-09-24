var tickets = null;

$(document).ready(function () {


    $('#tickets').DataTable({
        "bFilter": false,
        "bSort": false,
        "bLengthChange": false
    });

    loadCategories();

    loadStatuses();

    loadTickets();

    $("#new-ticket").on("click", function () {
        $("#ticket-number").val('');
        $("#ticket-description").val('');
        $("#ticket-comment").val('');
        $("#ticket-status").val('');
        $("#ticket-category").val('');
        $("#ticket-modal").modal('show');
    });

    $("#save").on("click", function () {
        upsert();
    });

    $("#search").on("click", function () {

        var filteredTickets = tickets;

        if ($("#search-ticket-number").val() !== '') {
            filteredTickets = filteredTickets.filter(function (ticket) {
                return ticket.ticketNumber == $("#search-ticket-number").val()            
            });
        }

        if ($("#search-status").val() !== '-1') {
            filteredTickets = filteredTickets.filter(function (ticket) {
                return ticket.status.code == $("#search-status").val() 
            });
          
        }

        if ($("#search-category").val() !== '-1') {
            filteredTickets = filteredTickets.filter(function (ticket) {
                return ticket.category.code == $("#search-category").val()
            });
        }

        fillDataTable(filteredTickets);

    });


    $("body").on("click", "#tickets tbody tr", function (e) {

        var ticketNumber = $(this).attr("data-number");

        var ticket = tickets.find(x => x.ticketNumber == ticketNumber);

        $("#ticket-number").val(ticket.ticketNumber);
        $("#ticket-description").val(ticket.description);
        $("#ticket-comment").val(ticket.comment);
        $("#ticket-status").val(ticket.status.code);
        $("#ticket-category").val(ticket.category.code);

        $("#ticket-modal").modal('show');
    });



});

function upsert() {
    var ticketRequest = {
        ticketNumber: $("#ticket-number").val(),
        description: $("#ticket-description").val(),
        comment: $("#ticket-comment").val(),
        status: $("#ticket-status").val(),
        category: $("#ticket-category").val()
    };

    $.ajax({
        type: "POST",
        url: "/api/upsert",
        data: ticketRequest,
        dataType: 'json',
        success: function (ticketResponse) {
            $("#ticket-modal").modal('hide');
            loadTickets();

        }
    });
}

function loadTickets() {
    $.get("/api/tickets", function (ticketsInfo) {

        tickets = ticketsInfo;
        fillDataTable(tickets);

    });
}

function fillDataTable(tickets) {
    $("#tickets tbody").empty();

    var html = '';
    $.each(tickets, function (index, ticket) {

        var row = '<tr class = "edit-ticket" data-number ="' + ticket.ticketNumber + '">';
        row += '<td><div >' + ticket.ticketNumber + ' <span class="glyphicon glyphicon-pencil"></span></div></td>';
        row += '<td>' + ticket.description + '</td>';
        row += '<td>' + ticket.status.name + '</td>';
        row += '<td>' + ticket.category.description + '</td>';
        row += '<td>' + ticket.creationDate + '</td>';
        row += '<td>' + ticket.lastUpdateDate + '</td>';
        row += '</tr>';

        html += row;
    });
    $("#tickets tbody").append(html);
}

function loadCategories() {
    $.get("/api/categories", function (categories) {

        $.each(categories, function (index, category) {
            $("#search-category").append("<option value=" + category.code + ">" + category.description + "</option>");
            $("#ticket-category").append("<option value=" + category.code + ">" + category.description + "</option>");
        });

    });
}

function loadStatuses() {
    $.get("/api/statuses", function (statuses) {

        $.each(statuses, function (index, status) {
            $("#search-status").append("<option value=" + status.code + ">" + status.name + "</option>");
            $("#ticket-status").append("<option value=" + status.code + ">" + status.name + "</option>");
        });

    });
}
