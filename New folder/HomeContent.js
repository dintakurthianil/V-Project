var clientContext = SP.ClientContext.get_current(); //gets the current context
var web = clientContext.get_web(); //gets the web object
var list; //gets the collection of lists
var targetList;
var results;
var itemColl;
var CEOMesageCollection;
var divsmart = "divSmart";
var itemIndex=0;
var istrue = false;
var isholidday = false;
$(document).ready(function () {

   
    // ExecuteOrDelayUntilScriptLoaded(function () { getSmatTools() }, "SP.js");
    $("#btnSmatToolIndia").click(function () {
        var country = "India"
        results = "";
        itemColl = "";
        list = "";
        // ExecuteOrDelayUntilScriptLoaded(function () { getSmatTools(country) }, "SP.js");
        $("#idSmartIndia").removeClass("button-india");
        $("#idSmartIndia").addClass("button-ind-active");

        $("#idSmartUsa").removeClass("button-usa-active");
        $("#idSmartUsa").addClass("button-usa")
        getSmatTools(country);
    });

    $("#btnSmatTooUSA").click(function () {
        var country = "USA";
        results = "";
        itemColl = "";
        list = "";
        $("#idSmartUsa").removeClass("button-usa");
        $("#idSmartUsa").addClass("button-usa-active");
        $("#idSmartIndia").removeClass("button-ind-active");
        $("#idSmartIndia").addClass("button-india");

        
        getSmatTools(country);
        
    });

    $("#btnHolidayIndia").click(function () {
        var country = "India"
        results = "";
        itemColl = "";
        list = "";       
        getHoliday(country);
        isholidday = true;
        
        $("#hncMorHoliday").attr('href', "/SitePages/CurrentHolidays.aspx?ctype=india");
        $("#divIndiaHoliday").removeClass("button-india");
        $("#divIndiaHoliday").addClass("button-ind-active");

        $("#divUSAHoliday").removeClass("button-usa-active");          
        $("#divUSAHoliday").addClass("button-usa")

    });

    $("#btnHolidayUSA").click(function () {
        var country = "USA";
        results = "";
        itemColl = "";
        list = "";
        isholidday = true;
        //ExecuteOrDelayUntilScriptLoaded(function () { getSmatTools(country) }, "SP.js");
        $("#divUSAHoliday").removeClass("button-usa");
        $("#divUSAHoliday").addClass("button-usa-active");
        $("#divIndiaHoliday").removeClass("button-ind-active");
        $("#divIndiaHoliday").addClass("button-india");
        getHoliday(country);
        $("#hncMorHoliday").attr('href', "/SitePages/CurrentHolidays.aspx?ctype=usa");
    });

    
    var hdnCountryId = loadids("hdnCountry");
    var countryName = $("#" + hdnCountryId).val();
    if (countryName == "India") {
        $("#hncMorHoliday").attr('href', "/SitePages/CurrentHolidays.aspx?ctype=india");
        $("#divIndiaHoliday").removeClass("button-india");
        $("#divIndiaHoliday").addClass("button-ind-active");
        $("#divUSAHoliday").addClass("button-usa");

        $("#idSmartIndia").removeClass("button-india");
        $("#idSmartIndia").addClass("button-ind-active");
        $("#idSmartUsa").addClass("button-usa");

        $("#divwhatsIndia").removeClass("button-india");
        $("#divwhatsIndia").addClass("button-ind-active");
        $("#divwhatsUsa").addClass("button-usa");

        $("#divIndiaJob").removeClass("button-india");
        $("#divIndiaJob").addClass("button-ind-active");
        $("#divUsaJob").addClass("button-usa");

           }

    else {
        $("#hncMorHoliday").attr('href', "/SitePages/CurrentHolidays.aspx?ctype=USA");
        $("#divUSAHoliday").removeClass("button-usa");
        $("#divUSAHoliday").addClass("button-usa-active");
        $("#divIndiaHoliday").addClass("button-india");

        $("#idSmartUsa").removeClass("button-usa");
        $("#idSmartUsa").addClass("button-usa-active");
        $("#idSmartIndia").addClass("button-india");

        $("#divwhatsUsa").removeClass("button-usa");
        $("#divwhatsUsa").addClass("button-usa-active");
        $("#divwhatsIndia").addClass("button-india");

        $("#divUsaJob").removeClass("button-usa");
        $("#divUsaJob").addClass("button-usa-active");
        $("#divIndiaJob").addClass("button-india");
    }
    

    $("#btnWhatsNewIndia").click(function () {
        var country = "India"
        results = "";
        itemColl = "";
            list = "";
        // ExecuteOrDelayUntilScriptLoaded(function () { getSmatTools(country) }, "SP.js");
            $("#divwhatsIndia").removeClass("button-india");
            $("#divwhatsIndia").addClass("button-ind-active");

            $("#divwhatsUsa").removeClass("button-usa-active");
            $("#divwhatsUsa").addClass("button-usa")
            getWhatsNew(country);
    });

    $("#btnWhatsNewUSA").click(function () {
        var country = "USA";
        results = "";
        itemColl = "";
        list = "";
        $("#divwhatsUsa").removeClass("button-usa");
        $("#divwhatsUsa").addClass("button-usa-active");
        $("#divwhatsIndia").removeClass("button-ind-active");
        $("#divwhatsIndia").addClass("button-india");
        //ExecuteOrDelayUntilScriptLoaded(function () { getSmatTools(country) }, "SP.js");
        getWhatsNew(country);
    });

    $("#ancIndia").click(function () {
        $("#divIndiaJob").removeClass("button-india");
        $("#divIndiaJob").addClass("button-ind-active");

        $("#divUsaJob").removeClass("button-usa-active");
        $("#divUsaJob").addClass("button-usa")
    });

    $("#ancUsa").click(function () {
        $("#divUsaJob").removeClass("button-usa");
        $("#divUsaJob").addClass("button-usa-active");
        $("#divIndiaJob").removeClass("button-ind-active");
        $("#divIndiaJob").addClass("button-india");
    });
   
    //hrNext

    $("#hrNext").click(function () {
       // getCEOItembyindexOne();
    });
   // getCEOMessage();
});

//function for get Smart Tools
function getSmatTools(country) {
    //debugger;
    list = web.get_lists().getByTitle("Smart Tools");
    var query1 = new SP.CamlQuery();
    var stryquery = "<View><Query><Where><Eq><FieldRef Name='Country' /><Value Type='LookUp' >" + country + "</Value></Eq></Where></Query><RowLimit>4</RowLimit></View>";

    query1.set_viewXml(stryquery);

    itemColl = list.getItems(query1);

    clientContext.load(itemColl);
    clientContext.executeQueryAsync(retrieveListItemsSuccess, retrieveListItemsFail);
}
function retrieveListItemsSuccess() {
    var iddiv = loadids("SmatTool");
    $("#" + iddiv).html("");
    if (itemColl.get_count() > 0) {

        var listItemEnumerator = itemColl.getEnumerator();
        result = "<ul>";
        while (listItemEnumerator.moveNext()) {
            var oListItem = listItemEnumerator.get_current();
            var listDetails = "<li><a href=" + oListItem.get_item('URL').get_url() + " target='_blank'>" + oListItem.get_item('Tool_x0020_Name') + "</a></li>";
            result = result + listDetails;
        }
        result = result + "</ul>";

        $("#" + iddiv).html(result);
    }
    else {

        $("#" + iddiv).html("No Smart Tools available");
    }

}
// This function is executed if the above call fails
function retrieveListItemsFail(sender, args) {
    alert('Failed to get list items. Error:' + args.get_message());
}
//end function Smart Tool 

function getHoliday(country) {
   
    list = web.get_lists().getByTitle("Holidays");
    var query = new SP.CamlQuery();


    var today = new Date();
    var mm = today.getMonth()
    var yyyy = today.getFullYear();
    var monthStart = new Date(yyyy, mm, 1);
    var monthEnd = new Date(yyyy, mm + 1, 1);
    var firstday = monthStart.getFullYear() + "-" + (monthStart.getMonth() + 1) + "-" + monthStart.getDate();
    var lastday = monthEnd.getFullYear() + "-" + (monthEnd.getMonth() + 1) + "-" + monthEnd.getDate();
    
  //var stryquery = "<View><Query><Where><And><And><And><Geq><FieldRef Name='HolidayDate' /><Value Type='DateTime'>" + firstday + "</Value></Geq><Leq><FieldRef Name='HolidayDate' /><Value Type='DateTime'>" + lastday + "</Value></Leq></And><Eq><FieldRef Name='Country' /><Value Type='Choice'>" + country + "</Value></Eq></And><Eq><FieldRef Name='FiscalYear' /><Value Type='Lookup'>" + yyyy + "</Value></Eq></And></Where></Query><RowLimit>4</RowLimit></View>";

    var stryquery = "<View><Query><Where><And><And><And><Geq><FieldRef Name='HolidayDate' /><Value Type='DateTime'>" + firstday + "</Value></Geq><Leq><FieldRef Name='HolidayDate' /><Value Type='DateTime'>" + lastday + "</Value></Leq></And><Eq><FieldRef Name='Country' /><Value Type='Choice'>" + country + "</Value></Eq></And><Eq><FieldRef Name='FiscalYear' /><Value Type='Lookup'>" + yyyy + "</Value></Eq></And></Where><OrderBy><FieldRef Name='HolidayDate' Ascending='True' /></OrderBy></Query><RowLimit>3</RowLimit></View>";

    query.set_viewXml(stryquery);

    itemColl = list.getItems(query);

    clientContext.load(itemColl);
    clientContext.executeQueryAsync(retrieveHolidaysListItemsSuccess, retrieveHolidaysListItemsFail);
}
function retrieveHolidaysListItemsSuccess() {
   
    var iddiv = loadids("Holiday");
    $("#" + iddiv).html("");
    if (itemColl.get_count() > 0) {

        var listItemEnumerator = itemColl.getEnumerator();
        result = "<ul>";
        var listDetails=""
        while (listItemEnumerator.moveNext()) {
            var oListItem = listItemEnumerator.get_current();
             listDetails += "<li>";
            if (oListItem.get_item('Country') == "India") {
                listDetails += "<img src='/_layouts/15/VrtxIntranetStyles/Images/indian-flag.jpg' width='30' height='19' />";
            }
            else {
                listDetails += "<img src='/_layouts/15/VrtxIntranetStyles/Images/usa-flag.jpg' width='30' height='19' />";
            }

            var hHadte = oListItem.get_item('HolidayDate')
            var formatedDate = getDateFormat(hHadte)
            listDetails += "<p>"+formatedDate +" "+oListItem.get_item('Title')+"</p>";
            listDetails += "</li>";
        
        }
        result = result + listDetails;
        result = result + "</ul>";

        $("#" + iddiv).html(result);
    }
    else {

        $("#" + iddiv).html("<img src='/_layouts/15/VrtxIntranetStyles/Images/no-holidays.jpg' />");
    }

}
function retrieveHolidaysListItemsFail(sender, args) {
    alert('Failed to get list items. Error:' + args.get_message());
}



var countryval;

function getWhatsNew(country) {
    //debugger;
    var today = new Date();
    var mm = today.getMonth()
    var date = today.getFullYear();
    countryval = country;
    list = web.get_lists().getByTitle("WhatsNew");
    var query1 = new SP.CamlQuery();
  //var stryquery = "<View><Query><Where><And><Eq><FieldRef Name='Country' /><Value Type='Choice'>{0}</Value></Eq><And><Eq><FieldRef Name='FiscalYear' /><Value Type='Lookup'>" + date + "</Value></Eq><Eq><FieldRef Name='ShowOnHomePage' /><Value Type='bit'>{1}</Value></Eq></And></And></Where><OrderBy><FieldRef Name= 'Modified' Ascending='FALSE'/></OrderBy></Query><RowLimit>1</RowLimit></View>";
    var stryquery = "<View><Query><Where><And> <And><Eq><FieldRef Name='Country' /><Value Type='Choice'>" + country + "</Value></Eq><Eq><FieldRef Name='ShowOnHomePage' /><Value Type='bit'>1</Value></Leq></And><Eq><FieldRef Name='FiscalYear' /><Value Type='Lookup'>" + date + "</Value></Eq></And></Where><OrderBy><FieldRef Name= 'Modified' Ascending='FALSE'/></OrderBy></Query><RowLimit>1</RowLimit></View>"
    query1.set_viewXml(stryquery);

    itemColl = list.getItems(query1);

    clientContext.load(itemColl);
    clientContext.executeQueryAsync(retrieveWhatsNewListItemsSuccess, retrievewhatsNewListItemsFail);
}
function retrieveWhatsNewListItemsSuccess() {
   //debugger// ebugger;
    var iddiv = loadids("WhatsNews");
    $("#" + iddiv).html("");
    if (itemColl.get_count() > 0) {

        var listItemEnumerator = itemColl.getEnumerator();
        result = "";
        while (listItemEnumerator.moveNext()) {
            var oListItem = listItemEnumerator.get_current();
            var eventTitle = oListItem.get_item('Title');
            var evnetDescription = oListItem.get_item('EventDescription');
            var eventdate = oListItem.get_item('EventDate');
            var listDetails = "<b>"+eventTitle + "</b><br/>";
            listDetails += "<b>" + getDateFormat(eventdate) + "</b><br/>";
            listDetails += "<p>"+evnetDescription.substring(0,200)+"...."+"</p>";
            result = result + listDetails;
        }
       

        $("#" + iddiv).html(result);
    }
    else {

        $("#" + iddiv).html("No Events available ");
    }

}
// This function is executed if the above call fails
function retrievewhatsNewListItemsFail(sender, args) {
    alert('Failed to get list items. Error:' + args.get_message());
}

//--------------------------------
function getDateFormat(listdate)
{
    var days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
    var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];

    var day = days[listdate.getDay()];
    var month = months[listdate.getMonth()];
    var year=listdate.getFullYear();
   // September 09, 2014 (Monday) Ganesh Chaturthi

    return month + " " + listdate.getDate() + ", " + listdate.getFullYear() + " " + "(" + day+")";

}
//===============================more announcement==================================
/*
function getCEOMessage()
{
    //debugger;
    list = web.get_lists().getByTitle("CEOMessage");
    var queryCEO = new SP.CamlQuery();
    var stryquery = "<View><RowLimit>3</RowLimit></View>"
    queryCEO.set_viewXml(stryquery);

    CEOMesageCollection = list.getItems(queryCEO);

    clientContext.load(CEOMesageCollection);
   clientContext.executeQueryAsync(retrieveCEOMessageListItemsSuccess, retrieveCEOMessageListItemsFail);

}*/
  /*
function getCEOItembyindexOne()
{
  debugger;
    var iddiv = loadids("divmessage");
    $("#" + iddiv).html("");
    var listCount = CEOMesageCollection.get_count();
    if (listCount > 0) 
       
        if(2 == itemIndex) 
        {
            itemIndex = 0; 
            
        }
        else
         itemIndex = itemIndex + 1;
    
        var listItem = CEOMesageCollection.itemAt(itemIndex);
        // var CEOTitle = listItem.get_item('Title');
        var CEODesc = listItem.get_item('Message')
       // var attachments = listItem.get_item('Attachments');
        var attachments = listItem.get_attachmentFiles();
        clientContext.load(attachments);

        clientContext.executeQueryAsync(Function.createDelegate(this, function(sender, args){
            debugger;
            var enums = attachments.getEnumerator();
            while (enums.moveNext()) { 
                var attacha = enums.get_current();
                var attachemurl=attacha.get_serverRelativeUrl();
            } 
            
        }), Function.createDelegate(this, function(){})); Function.createDelegate(this, function(){});


        $("#" + iddiv).html(CEODesc);
        
    
    
}
function retrieveCEOMessageListItemsSuccess() {
    //debugger;
    return CEOMesageCollection;

}
function retrieveCEOMessageListItemsFail(sender, args) {
    alert('Failed to get list items. Error:' + args.get_message());
}*/
//======================================end more announcement========