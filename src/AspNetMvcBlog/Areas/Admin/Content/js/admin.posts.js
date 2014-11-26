jQuery(function ($) {

    var $postTable = $('#posts-table');

    $postTable.dataTable({
        "bProcessing": true,
        "bServerSide": true,
        "bAutoWidth": false,
        "sAjaxSource": $postTable.attr('data-ajax-source'),
        "aoColumns": [
            {
                "sTitle": "Title",
                "mDataProp": "Title",
                "bSortable": false
            },
            {
                "sTitle": "Published On",
                "mDataProp": "PublishedOn",
                "sWidth": "100px",
                "bSortable": false
            },
            {
                "sTitle": "",
                "mDataProp": "",
                "sWidth": "110px",
                "bSortable": false,
                "mRender": function (innerData, sSpecific, oData) {
                    var render = '<a class="btn btn-default btn-sm" href="' + oData.EditUrl + '">Edit</a>';
                    render += '&nbsp;';
                    render += '<a class="btn btn-danger btn-sm" href="' + oData.DeleteUrl + '">Delete</a>';
                    return render;
                }
            }
        ]
    });

});