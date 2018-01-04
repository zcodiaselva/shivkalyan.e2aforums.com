/*
 * SJGrid - jQuery grid
 * Author - Sarabjit Sohal
 * Date: 112009
 */
 
(function ($) {

    var tt = new Object();

    var varIsPaginationRequired = "YES";

    $.addGrid = function (t, p) {
        if (t.grid)
            return false; //return if already exist	

        // apply default properties
        p = $.extend(

		    {
		        width: 'auto', //auto width			 
		        url: false, //ajax url			 
		        method: 'POST', // data sending method
		        striped: true, // apply odd even stripes
		        dataType: 'xml', // type of data loaded
		        errormsg: 'Connection Error',
		        rp: 10, // results per page			 			 
		        sortname: '', //column name to be sorted
		        sortorder: 'desc',
		        query: '',
		        qtype: '',
		        rows: 'none',
		        action: 'none',
		        searchSection: false,
		        setUrlOnSearchButtonClick: false,
		        newUrl: '',
		        showSearchSectionForcibly: false,
		        searchText: 'Search',
		        checkboxes: false,
		        attachment: false,
		        procmsg: 'Processing, please wait ...',
		        nomsg: 'No items',
		        onSuccess: false
		    }, p);

        $(t)
		.show() //show if hidden

        //create model if any
        if (p.colModel) {
            varObjTableId = $(t).attr("id");

            thead = document.createElement('thead');
            tr = document.createElement('tr');
            $(tr).attr('id', 'tableHeader_' + varObjTableId + '');
            var counter = 0;

            if (p.checkboxes) {

                var th = document.createElement('th');
                //#A JK:113009
                th.innerHTML = "<input type=\"checkbox\" id=\"chkAll_" + varObjTableId + "\" onclick=\"SelectDeselectAllCheckBoxes(this);\" />";
                //$(th).attr('width',20);
                $(th).attr('axis', 'col' + counter);
                $(tr).append(th);
                counter++;
            }

            if (p.attachment) {
                var th = document.createElement('th');
                th.innerHTML = "";
                $(th).attr('width', 20);
                $(th).attr('axis', 'col' + counter);
                $(tr).append(th);
                counter++;
            }

            for (i = 0; i <= p.colModel.length - 1; i++) {
                var cm = p.colModel[i];
                var th = document.createElement('th');

                th.innerHTML = cm.display;

                if (cm.sortable) {
                    th.innerHTML += "&#160;<img id=\"imgdesc" + cm.name + "\"  src='images/down.png' alt=''/><img id=\"imgasc" + cm.name + "\" src='images/up.png' alt='' style='display:none;'/>";
                }

                if (cm.name && cm.sortable)
                    $(th).attr('abbr', cm.name);

                $(th).attr('id', cm.name);

                $(th).attr('style', 'cursor:pointer; cursor: hand;');

                $(th).attr('axis', 'col' + (parseInt(i) + parseInt(counter)));



                if (cm.align)
                    th.align = cm.align;

                if (cm.width)
                    $(th).attr('width', cm.width);

                if (cm.hide) {
                    th.hide = true;
                }

                if (cm.process) {
                    th.process = cm.process;
                }

                if (cm.sortable) {
                    $(th).click(function () { g.SortData(this)/*;sortclicked(this);*/ });
                }

                $(tr).append(th);

            }

            $(thead).append(tr);
            $(tr).attr('class', 'testBorder');
            $(t).prepend(thead);

            varTotalColumns = p.colModel.length + counter;



        } // end if p.colmodel	



        //create grid class
        var g = {

            //get latest data
            populate: function () {

                if (this.loading)
                    return true;

                this.loading = true;

                if (!p.url)
                    return false;

                $('#tableBody_' + varObjTableId + '').remove();

                var tbody = document.createElement('tbody');
                tbody.id = "tableBody_" + varObjTableId + "";

                var tr_tbody = document.createElement('tr');
                tr_tbody.id = "tr_busy_" + varObjTableId + "";

                var td_tbody = document.createElement('td');
                td_tbody.align = "center";
                td_tbody.colSpan = varTotalColumns;
                td_tbody.innerHTML = '<img alt="Loading..." src="images/progressing.gif" />';

                $(tr_tbody).append(td_tbody);

                $(tbody).append(tr_tbody);

                $(t).append(tbody);


                // Loading message
                //$('.pPageStat',this.pDiv).html(p.procmsg);				
                //$('.pReload',this.pDiv).addClass('loading');

                if (!p.newp) p.newp = 1;

                if (p.page > p.pages) p.page = p.pages;


                p.rows = rowsChecked;

                var param = [
					 { name: 'page', value: p.newp }
					, { name: 'rp', value: p.rp }
					, { name: 'sortname', value: p.sortname }
					, { name: 'sortorder', value: p.sortorder }
					, { name: 'query', value: p.query }
					, { name: 'qtype', value: p.qtype }
					, { name: 'action', value: p.action }
					, { name: 'rows', value: p.rows }
				];

                if (p.params) {
                    for (var pi = 0; pi < p.params.length; pi++)
                        param[param.length] = p.params[pi];
                }

                $.ajax({
                    type: p.method,
                    url: p.url,
                    data: param,
                    dataType: p.dataType,
                    success: function (data) {
                        g.addData(data);
                        p.action = "none";
                        $('#actions_' + varObjTableId).val("-1");
                    },
                    error: function (data) {
                        try {
                            if (p.onError)
                                p.onError(data);
                        }
                        catch (e)
				        { }
                    }
                });

                return false;
            },
            addData: function (data) {
                if (varSortColumnName != "") {
                    if (p.sortorder == "asc") {
                        $("#imgdesc" + varSortColumnName + '').hide();
                        $("#imgasc" + varSortColumnName + '').hide();
                        $("#imgasc" + varSortColumnName + '').show();
                    }
                    else {
                        $("#imgdesc" + varSortColumnName + '').hide();
                        $("#imgasc" + varSortColumnName + '').hide();
                        $("#imgdesc" + varSortColumnName + '').show();

                    }
                }


                //$('.pReload',this.pDiv).removeClass('loading');
                this.loading = false;
                $('#tr_busy_' + varObjTableId + '').hide();

                $('#chkAll_' + varObjTableId + '').attr("checked", false);

                rowsChecked.splice(0, rowsChecked.length);

                if (!data) {
                    //$('.pPageStat',this.pDiv).html(p.errormsg);	
                    return false;
                }


                if (p.dataType == 'xml')
                    p.total = +$('rows total', data).text();
                else
                    p.total = data.total;

                ldblTotalMessagesCount = p.total;

                if (p.dataType == 'xml') {
                    if (+$('rows unread', data).text() != '')
                        varUnreadCount = +$('rows unread', data).text();
                }
                var tbody = document.getElementById('tableBody_' + varObjTableId + '');

                if (p.total == 0) {
                    $('tr, a, td, div', t).unbind();
                    //$(t).empty();
                    p.pages = 1;
                    p.page = 1;

                    var tr_norecord = document.createElement('tr');

                    var td_norecord = document.createElement('td');
                    td_norecord.align = "center";
                    td_norecord.colSpan = varTotalColumns;
                    td_norecord.innerHTML = '<b>No record found.</b>';

                    $(tr_norecord).append(td_norecord);

                    $(tbody).append(tr_norecord);

                    p.onSuccess();


                    if (p.showSearchSectionForcibly) {
                    }
                    else {
                        //this.buildpager();
                        //$('.pPageStat',this.pDiv).html(p.nomsg);
                        return false;
                    }



                }

                if (p.total <= p.rp) {
                    varIsPaginationRequired = "NO";
                }
                else {
                    varIsPaginationRequired = "YES";
                }

                p.pages = Math.ceil(p.total / p.rp);

                if (p.dataType == 'xml')
                    p.page = +$('rows page', data).text();
                else
                    p.page = data.page;

                //this.buildpager();

                //build new body
                //var tbody = document.createElement('tbody');

                $('#tr_busy_' + varObjTableId + '').remove();


                if (p.dataType == 'xml') {


                    i = 1;

                    $("rows row", data).each
				    (
				 	    function () {

				 	        i++;

				 	        var tr = document.createElement('tr');

				 	        if (i % 2 && p.striped)
				 	            tr.className = 'alt';

				 	        if ($(this).attr('unread').toUpperCase() == 'TRUE') {
				 	            tr.className += ' unread';
				 	        }
				 	        
//				 	        if ($(this).attr('rowcolor').toUpperCase() != '') {
//				 	            tr.className += " "+ $(this).attr('rowcolor');
//				 	        }				 	        

				 	        var nid = $(this).attr('id');
				 	        if (nid) tr.id = 'row' + nid;

				 	        nid = null;

				 	        var robj = this;

				 	        $('#tableHeader_' + varObjTableId + ' > th').each
							(
							 	function () {

							 	    var td = document.createElement('td');
							 	    var idx = $(this).attr('axis').substr(3);

							 	    td.align = this.align;
							 	    td.innerHTML = $("cell:eq(" + idx + ")", robj).text();
							 	    $(tr).append(td);


							 	    td = null;
							 	}
							);

				 	        $(tbody).append(tr);
				 	        tr = null;
				 	        robj = null;
				 	    }
				    );

                }

                $('tr', t).unbind();


                //$('tbody').remove();

                $('#search-div_' + varObjTableId + '').remove();

                $('#table_options_' + varObjTableId + '').remove();

                $('#pagination_' + varObjTableId + '').remove();


                //$(t).append(tbody);

                //this.addCellProp();
                //this.addRowProp();

                if (p.searchSection)
                    g.generateSearchSection();

                if (p.generateActions)
                    g.generateActions();


                if (p.pagination) {
                    // $('#table_options').empty();
                    g.pagination();
                }


                $('#next_' + varObjTableId + '').click(function () { g.changePage('next', this) });
                $('#prev_' + varObjTableId + '').click(function () { g.changePage('prev', this) });
                $('#first_' + varObjTableId + '').click(function () { g.changePage('first', this) });
                $('#last_' + varObjTableId + '').click(function () { g.changePage('last', this) });
                $('#txtPageNo_' + varObjTableId + '').change(function () { g.changePage('input', this) });
                $('#actions_' + varObjTableId + '').change(function () { g.onActionClick(this) });
                $('#btnSearch_' + varObjTableId + '').click(function () { g.onSearchClick(this) });
                $('#btnReset_' + varObjTableId + '').click(function () { g.onResetClick(this) });

                


                //this.rePosDrag();

                tbody = null; data = null; i = null;

                if (p.onSuccess)
                    p.onSuccess();

                //if (p.hideOnSubmit) $(g.block).remove();//$(t).show();

                //this.hDiv.scrollLeft = this.bDiv.scrollLeft;
                if ($.browser.opera) $(t).css('visibility', 'visible');



            },
            generateSearchSection: function () {

                var varSearchContent = '<div class="input-group" style="margin-right:30px;float:right;margin-bottom:15px;" id="search-div_' + varObjTableId + '">' +
	                                 '<input class="form-control" name="txtSearch" type="text" aria-controls="TblUserDetails" placeholder="Search" id="txtSearch_' + varObjTableId + '" "></span><span class="input-group-addon" style="width: 50px;"><a href="#"><i id="btnSearch_' + varObjTableId + '" class="fa fa-search"></i></a></span><span class="input-group-addon" style="width: 50px;"><a href="#"><image src="images/Refresh.png" id="btnReset_' + varObjTableId + '"/></a></span></div>';

               
                $(t).before(varSearchContent);
            },
            generateActions: function () {
               
                var varActionContent = '<div id="table_options_' + varObjTableId + '" class="tableActions" style=" background-color:#4780ae; border-left:2px solid #4780ae;border-top:2px solid #4780ae;border-bottom:1px solid #f9f9f9;border-right:2px solid #4780ae; width:56%; height:40px;">' +
			                           '<div style="margin-left:10px; margin-top:5px; color:#fff;">' +
			                           '<a href="#" onclick="return SelectDeselect(true);" style="color:#fff">Select All</a> | ' +
			                           '<a href="#" onclick="return SelectDeselect(false);" style="color:#fff">Select None</a> ' +
			                           '<select id="actions_' + varObjTableId + '" name="actions" style="width:150px;">' +
			                           '<option value="-1">Actions</option>';

                
                if (p.Actions) {
                    for (i = 0; i < p.Actions.length; i++) {
                        var action = p.Actions[i];

                        if (action.name == p.action) {
                            varActionContent += '<option selected="true" value="' + action.name + '">' + action.display + '</option>';
                        }
                        else {
                            varActionContent += '<option value="' + action.name + '">' + action.display + '</option>';
                        }
                    }
                }



                varActionContent += '</select>' +
			                           '</div>' +
			                           '</div>';

                $(t).before(varActionContent);

                //$('#actions').selectmenu({style:'dropdown'});
            },
            pagination: function () {
               
            
                var varPaginationContent = '<tfoot id="pagination_' + varObjTableId + '">' +
                                                     '<tr>' +
                                                     '<td colspan="' + varTotalColumns + '" class="pagination">' +
                                                     '<a id="first_' + varObjTableId + '" href="#">«« First</a> | ' +
                                                     '<a id="prev_' + varObjTableId + '" href="#">« Previous</a> | ' +
                                                     '<span style="color:black;">Page  <input style="height:20px;width:50px;" id="txtPageNo_' + varObjTableId + '" type="text" size="3" value="' + p.page + '" style="text-align:center; height: 12px;" /> of ' + p.pages + '&#8201;</span>' +
                                                     ' | <a id="next_' + varObjTableId + '" href="#">Next »</a> | ' +
                                                     '<a id="last_' + varObjTableId + '" href="#">Last »»</a>' +
                                                     '</td>' +
                                                     '</tr>' +
                                                     '</tfoot>';

             
                if (varIsPaginationRequired != "NO") {
                    $('#tableBody_' + varObjTableId + '').after(varPaginationContent);           //$('div').insertAfter('#table_options');
                }
            },
            changePage: function (ctype, objChange)//change page 
            {

                var ArrChangeDetails = objChange.id.split('_');

                varObjTableId = ArrChangeDetails[1];
                //if (this.loading) return true;

                switch (ctype) {
                    case 'first':

                        p.newp = 1;
                        break;

                    case 'prev':

                        if (p.page > 1)
                            p.newp = parseInt(p.page) - 1;
                        break;

                    case 'next':

                        if (p.page < p.pages)
                            p.newp = parseInt(p.page) + 1;
                        break;

                    case 'last':

                        p.newp = p.pages;
                        break;

                    case 'input':

                        var nv = parseInt($('#txtPageNo_' + varObjTableId + '').val());

                        if (isNaN(nv))
                            nv = 1;

                        if (nv < 1)
                            nv = 1;
                        else if (nv > p.pages)
                            nv = p.pages;

                        $('#txtPageNo_' + varObjTableId + '').val(nv);

                        p.newp = nv;

                        break;
                }


                if (p.newp == p.page)
                    return false;

                //if (p.onChangePage) 
                //	p.onChangePage(p.newp);
                //else				
                this.populate();
            },
            onActionClick: function (objAction) {

                var ArrActionDetails = objAction.id.split('_');

                varObjTableId = ArrActionDetails[1];

                if ($('#actions_' + varObjTableId + '').val() == -1)
                    return false;

                if (rowsChecked.length == 0) {
                    alert('Please select at least one row.');

                    return false;
                }

                p.action = $('#actions_' + varObjTableId + '').val();

                this.populate();

                return false;
            },
            onSearchClick: function (obj) {
                var ArrDetails = obj.id.split('_');

                varObjTableId = ArrDetails[1];

                if ($('#txtSearch_' + varObjTableId).val() != "") {
                    p.query = $('#txtSearch_' + varObjTableId).val();

                    if (p.setUrlOnSearchButtonClick)
                        p.url = p.newUrl;

                    this.populate();
                }
                return false;
            },
            onResetClick: function (obj) {
                var ArrDetails = obj.id.split('_');

                varObjTableId = ArrDetails[1];
                p.query = "";
                if (p.setUrlOnSearchButtonClick)
                    p.url = p.newUrl;
                this.populate();
                
                return false;
            },
            SortData: function (obj) {
                varSortColumnName = obj.id;

                p.sortname = varSortColumnName

                try {
                    if (p.sortorder == "desc") {
                        p.sortorder = "asc";


                    }
                    else {
                        p.sortorder = "desc";
                    }
                }
                catch (err) {
                    //alert(err.description );
                }
                varSortOrder = p.sortorder;
                this.populate();

                return false;
            }



        }


        //make grid functions accessible
        t.p = p;
        t.grid = g;



        // load data
        if (p.url) {
            g.populate();
        }



        return t;
    };

    var docloaded = false;
    var tt;
    $(document).ready(function () {
        // Setting the var = true to indicate that document has been loaded
        docloaded = true;
    });



    // generating the grid
    $.fn.SJGrid = function (p) {



        if (!docloaded) {

            $(this).hide();

            t = this;


            $(document).ready
				(
					function () {
					    $.addGrid(t, p);
					}
				);
        }
        else {

            tt = $.addGrid(this, p);
            //$.addGrid(this,p);


        }


    }; //end SJGrid

    $.fn.SJGridReload = function (p) // function to reload grid
    {
        if (tt != null) {
            if (tt.grid && tt.p.url)
                tt.grid.populate();
        }
        //        return this.each( function() {
        //				if (this.grid&&this.p.url) this.grid.populate();
        //			});

    }; //end SJGridReload

    $.fn.SJGridOptions = function (p) //function to update general options
    {
        if (tt != null) {
            if (tt.grid) {
                $.extend(tt.p, p);
            }
        }
        //        return this.each( function() {
        //				if (this.grid) $.extend(this.p,p);
        //			});

    }; //end SJGridReload


})(jQuery);

var rowsChecked = new Array();

var varObjTableId;
var varTotalColumns = 0;


function SelectDeselectAllCheckBoxes(varObjAllCheckbox)
{      
   rowsChecked.splice(0, rowsChecked.length);
   
   $("#"+varObjTableId+" tbody").find("tr").each(function(i) 
   {
        $(this).find("td:first").find("input").attr("checked", $(varObjAllCheckbox).attr("checked"));
        
        if($(varObjAllCheckbox).attr("checked"))
            rowsChecked[i] = $(this).find("td:first").find("input").attr("id").replace("chk", "");
   });   
   
   return false;
   
}

function SelectDeselect(varBoolValue)
{
    $('#chkAll_'+varObjTableId+'').attr("checked", varBoolValue);
    
    SelectDeselectAllCheckBoxes($('#chkAll_'+varObjTableId+''));   
    
    return false; 
    
}

function UpdateRowsCheckedArray(varObjCheckBox)
{
    if($(varObjCheckBox).attr("checked"))
    {        
          rowsChecked[rowsChecked.length] = $(varObjCheckBox).attr("id").replace("chk", "");   
          
          if($("#"+varObjTableId+" tbody").find("tr").length == rowsChecked.length)
                $('#chkAll_'+varObjTableId+'').attr("checked", true);
    }
    else
    {   
        for(var i=0; i<rowsChecked.length; i++)
        {
            if(rowsChecked[i] == $(varObjCheckBox).attr("id").replace("chk", ""))
            {
                rowsChecked.splice(i, 1);
                break;
            }
        }
        
        $('#chkAll_'+varObjTableId+'').attr("checked", false);
    }
    
    return false;
}

var varSortOrder = "";
var varSortColumnName = "";
/*function sortclicked(obj)
{
    alert("'imgdesc"+obj.id+"'");
    try
    {
        if(varSortOrder == "asc")
        {           
            document.body.getElementById("'imgdesc"+obj.id+"'").style.display = "block";
            document.body.getElementById("'imgasc"+obj.id+"'").style.display = "none";
            //$("'#" + tt + " th imgdesc"+obj.id+"'").hide();
            //$("'#" + tt + " th imgasc"+obj.id+"'").show();
                                	                    
        }
        else
        {
            document.body.getElementById("'imgdesc"+obj.id+"'").style.display = "none";
            document.body.getElementById("'imgasc"+obj.id+"'").style.display = "block";   
            //$("'#" + tt + " th imgdesc"+obj.id+"'").show();
            //$("'#" + tt + " th imgasc"+obj.id+"'").show();                   
        }
    }
    catch(err)
    {
        //alert(err.description );
    }
	            
}*/
	        