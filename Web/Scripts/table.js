﻿$(document).ready(function () {
    
    $('#data').dataTable({
        "lengthMenu": [[2, 16, 32], [2, 16, 32]],
        "language": {
            "sProcessing": "Đang xử lý...",
            "sLengthMenu": "Xem _MENU_ mục",
            "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
            "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
            "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
            "sInfoFiltered": "(được lọc từ _MAX_ mục)",
            "sInfoPostFix": "",
            "sSearch": "Tìm:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Đầu",
                "sPrevious": "Trước",
                "sNext": "Tiếp",
                "sLast": "Cuối"
            }
        },
        "processing": true,
        "serverSide": true,
        "ordering": false,
        "ajax": {
            "url": "/Home/GetList",
            "type": "post",
            "datatype": "json"
        },
        "columns": [ 
            {data: 'CategoryId'},
            {data: 'NameCategory'}
        ]
    });


})

