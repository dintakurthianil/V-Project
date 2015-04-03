var context;
var collListItem;
$(document).ready(function () {
    //debugger;
    ExecuteOrDelayUntilScriptLoaded(getEmplist, "sp.js");
    //    getEmplist();
});


function getEmplist() {
    //debugger;
    context = new SP.ClientContext.get_current();
    var oList = context.get_web().get_lists().getByTitle('EmpBasicInfo');

    var camlQuery = new SP.CamlQuery();
    //camlQuery.set_viewXml('<View><Query><Where><Geq><FieldRef Name=\'ID\'/>' + 
    //   '<Value Type=\'Number\'>1</Value></Geq></Where></Query><RowLimit>10</RowLimit></View>');
    camlQuery.set_viewXml('<View></View>');

    collListItem = oList.getItems(camlQuery);
    context.load(collListItem);
    context.executeQueryAsync(Function.createDelegate(this, this.onQuerySucceeded), Function.createDelegate(this, this.onQueryFailed));
}

function onQuerySucceeded() {
    var listItemInfo = '';

    var listItemEnumerator = collListItem.getEnumerator();
    var output = '';
    output += '<div id="printcontent"  style="overflow-x: auto; width:820px;">';
    output += '<table  cellpadding="0" cellspacing="0" border="0"  id="tblEmp" style="white-space: nowrap;padding-top:10px; " >';
    output += '<thead>';
    output += '<tr  >';
    output += '<th class="grid-header"  align="left" style="padding: 5px;" >S.No</th>'
    output += '<th class="grid-header"  align="left" style="padding-left:10px" >Emp ID</th>'
    output += '<th class="grid-header"  align="left" style="white-space: nowrap;padding-left:10px">First Name</th>'
    output += '<th class="grid-header"  align="left" style="padding-left:10px">Last Name</th>'
    output += '<th class="grid-header"  align="left" style="padding-left:10px">Gender</th>'
    output += '<th class="grid-header"  align="left" style="padding-left:10px">Email</th>'
    output += '<th class="grid-header"  align="left" style="padding-left:10px">Team</th>'
    output += '<th class="grid-header"  align="left" style="padding-left:10px">Domain</th>'
    output += '<th class="grid-header"  align="left" style="padding-left:10px">Phone-Residence</th>'
    output += '<th class="grid-header"  align="left" style="white-space: nowrap;padding-left:10px">Phone-Mobile</th>'
    output += '<th class="grid-header"  align="left" style="white-space: nowrap;padding-left:10px">Ofc Extn No</th>'
    output += '<th class="grid-header"  align="left" style="white-space: nowrap;padding-left:10px">ICQ No</th>'
    output += '<th class="grid-header"  align="left" style="padding-left:10px">Profile</th>'
    output += '</tr>';
    output += '</thead>';
    output += '<tbody>';
    var count = 0;
    while (listItemEnumerator.moveNext()) {
        count += 1;

        var oListItem = listItemEnumerator.get_current();
        //listItemInfo += '\nID: ' + oListItem.get_id() + 
        var title = oListItem.get_item('Title');
        var empID = oListItem.get_item('EmpID');
        var empFirstName = oListItem.get_item('First_x0020_Name');
        var empLastName = oListItem.get_item('Last_x0020_Name');
        var empGender = oListItem.get_item('Gender').get_lookupValue();

        var empEmailId = oListItem.get_item('VertexEmailID').get_lookupValue();

        var empDepartment = oListItem.get_item('Department').get_lookupValue();
        var empProfileTag = oListItem.get_item('ProfileTag');
        var profile = "";
        for (var i = 0; i < empProfileTag.length; i++) {
            var lookupObject = empProfileTag[i];

            profile += lookupObject.get_lookupValue()+",";

        }
        profile = profile.substr(0, profile.length - 1) + '';

        var empResidencePhoneNumber = oListItem.get_item('ResidencePhoneNumber');
        var empPhone = oListItem.get_item('MobileNumber');
        var empExtensionNumber = oListItem.get_item('ExtensionNumber');
        var ICQNumber = oListItem.get_item('ICQNumber');

        //var empName=empFirstName+" "+empLastName;

        if (empLastName == null) {
            empLastName = ""
        }
        if (empFirstName == null) {
            empFirstName = ""
        }
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

        if (empID == null)
            empID = ''

        if (empGender == null)
            empGender = ''

        if (empDepartment == null)
            empDepartment = ''

        if (profile == null)
            profile = ''

        if (empResidencePhoneNumber == null)
            empResidencePhoneNumber = ''



        output += '<tr>';

        output += '<td align="left" style="padding-left: 20px">' + count + '</td>';
        output += '<td align="left" style="padding-left: 10px">' + empID + '</td>';
        output += '<td align="left" style="padding-left: 10px">' + empFirstName + '</td>';
        output += '<td align="left" style="padding-left: 10px">' + empLastName + '</td>';
        output += '<td align="left" style="padding-left: 25px">' + empGender + '</td>';
        output += '<td align="left" style="padding-left: 10px"><a href=mailto:' + empEmailId + '>' + empEmailId + '</a></td>';
        output += '<td align="left" style="white-space: nowrap;padding-left: 10px">' + empDepartment + '</td>';
        output += '<td align="left" style="width:40px; padding-left: 10px">' + profile + '</td>';
        output += '<td align="left" style="padding-left: 10px">' + empResidencePhoneNumber + '</td>';
        output += '<td align="left" style="padding-left: 10px">' + empPhone + '</td>';
        output += '<td align="left" style="padding-left: 10px">' + empExtensionNumber + '</td>';
        output += '<td align="left" style="padding-left: 10px">' + ICQNumber + '</td>';
        output += '<td align="left" style="padding-left: 25px"><a  target="_blank" href="../SitePages/ODCServiceProfiles.aspx?username=' + title + '"><img src=/_layouts/15/VrtxIntranetStyles/Images/profile-icon.png ></a></td>';
        output += '</tr>';

    }
    output += '</tbody>';
    output += '</div>';
    //output+='</table>';
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
        "bAutoWidth": true
    });




}


function onQueryFailed(sender, args) {

    alert('Request failed. ' + args.get_message() + '\n' + args.get_stackTrace());
}