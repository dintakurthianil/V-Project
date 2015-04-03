$(document).ready(function () {
    //debugger;
    //ExecuteOrDelayUntilScriptLoaded(getEmplist, "sp.js");
    getEmplist();
});


function getEmplist() {
    debugger;
     var output = '';
    output += '<table  cellpadding="0" cellspacing="0" border="0"  id="tblEmp" style="width:100%" >';
    output += '<thead>';
    output += '<tr>';
    output += '<th class="grid-header"  align="left" style="padding-left:10px">Name</th>'
    output += '<th class="grid-header" align="left" style="padding-left:10px" >Email</th>'
    output += '<th class="grid-header"  align="left" style="padding-left:10px">Phone Number</th>'
    output += '<th class="grid-header" align="left" style="padding-left:10px">Ext Number</th>'
    output += '<th class="grid-header" align="left" style="padding-left:10px">ICQ Number</th>'
    output += '</tr>';
    output += '</thead>';
    output += '<tbody>';
    $().SPServices({
        operation: "GetListItems",
        async: false,
        listName: "EmpBasicInfo",
        //CAMLQuery: "<Query><OrderBy><FieldRef Name='Modified' Ascending='False' /></OrderBy></Query>",
      //  CAMLRowLimit: 1,
        completefunc: function (xData, Status) {
            $(xData.responseXML).SPFilterNode("z:row").each(function () {
               
                
                var empLastName = $(this).attr('ows_Last_x0020_Name');
                var empFirstName = $(this).attr('ows_First_x0020_Name');
                var empPhone = $(this).attr('ows_MobileNumber');
                var ICQNumber = $(this).attr('ows_ICQNumber');
                var empEmailId = $(this).attr('ows_VertexEmailID');
                var empExtensionNumber = $(this).attr('ows_ExtensionNumber');

                var empName = empFirstName + " " + empLastName;

                if (empPhone == null)
                    empPhone = ''

                if (ICQNumber == null)
                    ICQNumber = ''

                if (empEmailId == null)
                    empEmailId = ''

                if (empEmailId == null)
                    empEmailId = ''

                if (empExtensionNumber == null)
                    empExtensionNumber = ''


                output += '<tr>';

                output += '<td align="left" style="padding-left:10px">' + empName + '</td>';
                output += '<td align="left" style="padding-left:10px">' + empEmailId + '</td>';
                output += '<td align="left" style="padding-left:10px">' + empPhone + '</td>';
                output += '<td align="left" style="padding-left:10px">' + empExtensionNumber + '</td>';
                output += '<td align="left" style="padding-left:10px">' + ICQNumber + '</td>';
                output += '</tr>';
            });

            output += '</tbody>';
           output+='</table>';
            $('#tblEmpDetails').html(output);
            $("#tblEmp tbody tr:nth-child(even)").addClass("grid-sub1");
            $("#tblEmp tbody tr:nth-child(odd)").addClass("grid-sub2");

            $("#tblEmp th").addClass("grid-header");
            $('#tblEmp').dataTable({
                "bPaginate": false,
                "bLengthChange": false,
                "bFilter": true,
                "bSort": true,
                "bInfo": false,
                "bAutoWidth": false
            });

        }
    });
   


}

