﻿const uriList = 'api/todolist';
let todolists = null;
let selectList = 0;

$(document).ready(function () {
    getTodoList();
});

function getTodoList() {
    $.ajax({
        type: 'GET',
        url: uriList,
        success: function (data) {
            $('#todoLists').empty();
            if (selectList === 0) {
                $('<tr>' +
                    '<td>All</td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td><button disabled onclick="SelectList(0)">Selected</button></td>' +
                    '</tr>').appendTo($('#todoLists'));
            }
            else {
                $('<tr>' +
                    '<td>All</td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td><button onclick="SelectList(0)">Select</button></td>' +
                    '</tr>').appendTo($('#todoLists'));
            }
            $.each(data, function (key, list) {

                if (list.id === selectList) {
                    $('<tr>' +
                        '<td>' + list.name + '</td>' +
                        '<td><button onclick="editList(' + list.id + ')">Edit</button></td>' +
                        '<td><button onclick="deleteList(' + list.id + ')">Delete</button></td>' +
                        '<td><button onclick="SelectList(' + list.id + ')">Selected</button></td>' +
                        '</tr>').appendTo($('#todoLists'));
                }
                else {
                    $('<tr>' +
                        '<td>' + list.name + '</td>' +
                        '<td><button onclick="editList(' + list.id + ')">Edit</button></td>' +
                        '<td><button onclick="deleteList(' + list.id + ')">Delete</button></td>' +
                        '<td><button onclick="SelectList(' + list.id + ')">Select</button></td>' +
                        '</tr>').appendTo($('#todoLists'));
                }
                
            });

            todolists = data;
        }
    });
}

function deleteList(id) {
    $.ajax({
        url: uriList + '/' + id,
        type: 'DELETE',
        success: function (result) {
            getTodoList();
            getData();
        }
    });
}

function editList(id) {
    $.each(todolists, function (key, list) {
        if (list.id === id) {
            $('#edit-list-name').val(list.name);
            $('#edit-list-id').val(list.id);
        }
    });
    $('#listEdit').css({ 'display': 'block' });
}

function addList() {
    const list = {
        'name': $('#add-list-name').val()
    };

    $.ajax({
        type: 'POST',
        accepts: 'application/json',
        url: uriList,
        contentType: 'application/json',
        data: JSON.stringify(list),
        error: function (jqXHR, textStatus, errorThrown) {
            alert('here');
        },
        success: function (result) {
            getTodoList();
            $('#add-list-name').val('');
        }
    });
}

$('.my-list-form').on('submit', function () {
    const list = {
        'name': $('#edit-list-name').val(),
        'id': $('#edit-list-id').val()
    };

    $.ajax({
        url: uriList + '/' + $('#edit-list-id').val(),
        type: 'PUT',
        accepts: 'application/json',
        contentType: 'application/json',
        data: JSON.stringify(list),
        success: function (result) {
            getTodoList();
        }
    });

    closeListInput();
    return false;
});

function closeListInput() {
    $('#listEdit').css({ 'display': 'none' });
}

function SelectList(id) {
    selectList = id;
    getData();
    getTodoList();
}