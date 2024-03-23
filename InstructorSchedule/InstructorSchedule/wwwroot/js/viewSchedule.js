// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    var events = [];
    var selectedEvent = null;
    FetchEventAndRenderCalendar();



    function FetchEventAndRenderCalendar() {
        events = [];
        $.ajax({
            type: "GET",
            url: "/event/GetSchedule",
            success: function (data) {
                console.log("data", data);
                $.each(data, function (i, v) {
                        $.each(v, function (i, _e) {
                            events.push({
                                id: _e.id,
                                title: _e.subject.code,
                                description: _e.description,
                                start: _e.start,
                                end: _e.end,
                                color: _e.themeColor,
                                status: _e.status,
                                subject: _e.subject,
                            });
                        });
                })

                GenerateCalender(events);
            },
            error: function (error) {
                alert('failed');
            }
        })
    }

    function GenerateCalender(events) {
        var calendarEl = document.getElementById('calendar');
        var currentDate = new Date();

        var calendar = new FullCalendar.Calendar(calendarEl, {
            contentHeight: 700,
            initialView: 'dayGridMonth',
            initialDate: currentDate,
            headerToolbar: {
                left: 'prev,next today',
                center: 'title',
                right: 'dayGridMonth,timeGridWeek,timeGridDay,listWeek'
            },
            eventColor: "#378006",
            events: events,

            // EVENT CLICK ON========================
            eventClick: function (info) {
                var calEvent = info.event;
                console.log("Caled", calEvent);
                selectedEvent = calEvent;
                document.getElementById("eventTitle").textContent = selectedEvent.extendedProps.subject.code;
                var description = document.createElement("div");
                description.innerHTML = 
                    "<p><b>Subject: </b>" + selectedEvent.extendedProps.subject.name + 
                "<p><b>Start: </b> " + moment(selectedEvent.start).format("YYYY/MM/DD HH:mm A") +
                    "</p>" +
                (calEvent.end ? "<p><b>End: </b> " + moment(selectedEvent.end).format("YYYY/MM/DD HH:mm A") + "</p>" : "") +
                    "<p><b>Description: </b> " +
                    calEvent.extendedProps.description +
                    "</p>";

                var pDetails = document.getElementById("pDetails");
                pDetails.innerHTML = "";
                pDetails.appendChild(description);
                var modal = new bootstrap.Modal(document.getElementById("myModal"));
                modal.show();
            },
            selectable: true,
        });

        calendar.render();
    }

    function formatDate(inputDate) {
        var date = new Date(inputDate);
        var day = date.getDate().toString().padStart(2, '0');
        var month = (date.getMonth() + 1).toString().padStart(2, '0');
        var year = date.getFullYear();
        var hours = date.getHours().toString().padStart(2, '0');
        var minutes = date.getMinutes().toString().padStart(2, '0');

        var formattedDate = `${year}-${month}-${day}T${hours}:${minutes}`;

        return formattedDate;
    }


    $('#btnEdit').click(function () {
        //Open modal dialog for edit event
        openEditForm();
    })


    $('#btnDelete').click(function () {
        if (selectedEvent != null && confirm('Are you sure?')) {
            console.log(selectedEvent.id);
            $.ajax({
                type: "PUT",
                url: '/event/DeleteSchedule',
                data: { 'eventId': selectedEvent.id },
                success: function (data) {
                    if (data) {
                        //Refresh the calender
                        FetchEventAndRenderCalendar();
                        $('#myModal').modal('hide');
                    }
                    else {
                        alert('Delete failed!');
                    }
                },
                error: function () {
                    alert('Failed');
                }
            })
        }
    })


    function openAddForm() {
        console.log(selectedEvent.start);
        if (selectedEvent != null) {
            $('#hdEventID').val(selectedEvent.id);
            $('#txtSubject').val(selectedEvent.title);
            $('#txtStart').val(formatDate(selectedEvent.start.startStr));
            $('#txtEnd').val(formatDate(selectedEvent.end.endStr));
            $('#txtDescription').val(selectedEvent.description);
            $('#ddThemeColor').val(selectedEvent.backgroundColor);
        }
        $('#myModal').modal('hide');
        var modal = new bootstrap.Modal(document.getElementById("myModalSave"));
        modal.show();
    }
    function openEditForm() {
        if (selectedEvent != null) {
            $('#hdEventID').val(selectedEvent.id);
            $('#txtSubject').val(selectedEvent.title);
            $('#txtStart').val(formatDate(selectedEvent.start));

            $('#txtEnd').val(selectedEvent.end != null ? formatDate(selectedEvent.end) : '');
            $('#txtDescription').val(selectedEvent.extendedProps.description);
            $('#ddThemeColor').val(selectedEvent.backgroundColor);
        }
        $('#myModal').modal('hide');
        var modal = new bootstrap.Modal(document.getElementById("myModalSave"));
        modal.show();
    }
    $('#btnSave').click(function () {
        //Validation/
        if ($('#txtSubject').val().trim() == "") {
            alert('Subject required');
            return;
        }
        if (formatDate($('#txtStart').val()).trim() == "") {
            alert('Start date required');
            return;
        }
   
        var startDate = moment($('#txtStart').val()).format("YYYY/MM/DD HH:mm A");
        var endDate = moment($('#txtEnd').val()).format("YYYY/MM/DD HH:mm A");

      
        if ($('#txtEnd').val().trim() == "") {
            alert('End date required');
            return;
        }
        if (startDate > endDate) {
            alert('Invalid end date');
            return;
        }

        var data = {

            Id: $('#hdEventID').val(),
            Name: $('#txtSubject').val().trim(),
            Start: moment($('#txtStart').val()).format() ,
            End: moment($('#txtEnd').val()).format(),
            Description: $('#txtDescription').val(),
            ThemeColor: $('#ddThemeColor').val(),
            SubjectId: $('#ddSubjectId').val(),
            Status: 0,

        }
        SaveEvent(data);

    })
    function SaveEvent(data) {
        console.log("data", data);
        $.ajax({
            type: "POST",
            url: '/event/SaveSchedule',
            data: JSON.stringify(data),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {
                console.log("Data success", data);
                if (data) {
                    //Refresh the calender
                    FetchEventAndRenderCalendar();
                    $('#myModalSave').modal('hide');
                }
            },
            error: function () {
                alert('Failed');
            }
        })
    }

});