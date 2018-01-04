<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Invoice.aspx.cs" Inherits="response" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 700px;
        }
        .auto-style4
        {
            height: 38px;
        }
        .auto-style6
        {}
        .auto-style7
        {
            height: 22px;
        }
 p.MsoNormal
	{margin-bottom:.0001pt;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	        margin-left: 0in;
            margin-right: 0in;
            margin-top: 0in;
        }
        .auto-style8
        {
            width: 100.0%;
            font-size: 10.0pt;
            font-family: "Times New Roman", serif;
        }
    </style>
    
</head>
<body>

          
    <form id="form1" runat="server">
    <div>  

        <table align="center" class="auto-style1" style="font-family: 'Trebuchet MS'; font-size: 12px; width: 700px;" width="700px">
            <tr>
                <td style="text-align: center" colspan="2"> 
                    <a href="http://www.e2aforums.com/"><img src="img/logo.png" alt="e2aforums"></a>
                    <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/Ad_Panel/images/gyan jyoti header.jpg" 
                        Width="700px" />--%>
                </td>
               
            </tr>
             <tr>
                <td style="text-align: center" colspan="2"> 

                    &nbsp;</td>
               
            </tr>
            <tr>
                <td style="text-align: center" colspan="2"> 

                    <a href="#" onclick="window.print();return false;"><img id="Img1" alt="Print (Ctrl+P)" 
                        src="~/pay/img/bt_print.jpg" runat="server" align="left" 
                        title="Print " /></a><strong>Payment Information </strong></td>
               
            </tr>
            <tr>
                <td  colspan="2" align="right"> 

                   
                    <strong>Transaction ID:</strong> <asp:Label ID="lbl_trans_id" runat="server"></asp:Label>
                </td>
               
            </tr>
            <tr>
                <td colspan="2">
                    <hr /><strong style="text-align:left">Payer Information</strong>
                </td>
                
            </tr>
            <tr>
                <td colspan="2">
                    <hr />

                </td>
                
            </tr>
                <tr>
                <td class="auto-style6" colspan="2"><strong>ID:</strong> <asp:Label ID="lblBuyerid" runat="server"></asp:Label> </td>
            </tr>
                <tr>
                <td class="auto-style6" colspan="2" align="right"><strong>Name:</strong><asp:Label ID="blb_buyName" runat="server"></asp:Label> </td>
            </tr>
                <tr>
                <td class="auto-style6" colspan="2" align="right"><strong>Email:</strong> <asp:Label ID="lbl_buyer_Email" runat="server"></asp:Label> </td>
            </tr>
                <tr>
                <td colspan="2">
                    <hr /><strong style="text-align:left">Plan Descriptions</strong>
                <hr /></td>
                
            </tr>
            <tr>
                <td class="auto-style7">
                   
                   
                    </td>
                <td align="right" class="auto-style7">
                <strong style="text-align:right">Amount</strong>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                   
                   
                    <strong>Item ID: </strong> <asp:Label ID="lbl_Item_Id" runat="server"></asp:Label>
                   
                   
                </td>
                <td align="right">
                
                    <asp:Label ID="lbl_Total_amount1" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                   
                   
                    <strong>Item Name: </strong> <asp:Label ID="lbl_Item_name" runat="server"></asp:Label>
                   
                   
                </td>
                <td>
                
                </td>
            </tr>
            <tr>
                <td>
                   
                   
                    &nbsp;</td>
                <td>
                
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style4">
                   
                   <hr />
                   </td>
            </tr>
            <tr>
                <td align="right">
                   
                   
                    &nbsp;</td>
                <td align="right">
                
                    Total: <span>$</span><asp:Label ID="lbl_Total_amount" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                   
                   
                    &nbsp;</td>
                <td align="right">
                   
                   
                    <strong>Payment Date:</strong><asp:Label ID="lblPaymentDate" runat="server"></asp:Label> 
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">Terms &amp; Conditions:- </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table border="0" cellpadding="0" class="auto-style8" style="mso-cellspacing: 1.5pt; mso-yfti-tbllook: 1184; mso-padding-alt: 0in 0in 0in 0in" width="100%">
                        <tr style="mso-yfti-irow:0;mso-yfti-firstrow:yes;mso-yfti-lastrow:yes">
                            <td style="width:1.0%;border:none;border-right:solid #E5E5E5 1.0pt;
  padding:1.5pt 4.5pt .75pt 2.25pt" valign="top" width="1%">
                                <p class="MsoNormal">
                                    <span style="font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
  color:green"><!--[if gte vml 1]><v:shapetype id="_x0000_t75" coordsize="21600,21600"
   o:spt="75" o:preferrelative="t" path="m@4@5l@4@11@9@11@9@5xe" filled="f"
   stroked="f">
   <v:stroke joinstyle="miter" xmlns:v="urn:schemas-microsoft-com:vml"/>
   <v:formulas>
    <v:f eqn="if lineDrawn pixelLineWidth 0" xmlns:v="urn:schemas-microsoft-com:vml"/>
    <v:f eqn="sum @0 1 0" xmlns:v="urn:schemas-microsoft-com:vml"/>
    <v:f eqn="sum 0 0 @1" xmlns:v="urn:schemas-microsoft-com:vml"/>
    <v:f eqn="prod @2 1 2" xmlns:v="urn:schemas-microsoft-com:vml"/>
    <v:f eqn="prod @3 21600 pixelWidth" xmlns:v="urn:schemas-microsoft-com:vml"/>
    <v:f eqn="prod @3 21600 pixelHeight" xmlns:v="urn:schemas-microsoft-com:vml"/>
    <v:f eqn="sum @0 0 1" xmlns:v="urn:schemas-microsoft-com:vml"/>
    <v:f eqn="prod @6 1 2" xmlns:v="urn:schemas-microsoft-com:vml"/>
    <v:f eqn="prod @7 21600 pixelWidth" xmlns:v="urn:schemas-microsoft-com:vml"/>
    <v:f eqn="sum @8 21600 0" xmlns:v="urn:schemas-microsoft-com:vml"/>
    <v:f eqn="prod @7 21600 pixelHeight" xmlns:v="urn:schemas-microsoft-com:vml"/>
    <v:f eqn="sum @10 21600 0" xmlns:v="urn:schemas-microsoft-com:vml"/>
   </v:formulas>
   <v:path o:extrusionok="f" gradientshapeok="t" o:connecttype="rect" xmlns:v="urn:schemas-microsoft-com:vml"/>
   <o:lock v:ext="edit" aspectratio="t" xmlns:o="urn:schemas-microsoft-com:office:office"/>
  </v:shapetype><v:shape id="Picture_x0020_3" o:spid="_x0000_i1025" type="#_x0000_t75"
   alt="Description: Description: https://s3.amazonaws.com/images.wisestamp.com/widgets/green_32.png"
   style='width:24pt;height:24pt'>
   <v:imagedata src="file:///C:\Users\ADMINI~1\AppData\Local\Temp\1\msohtmlclip1\01\clip_image001.png"
    o:href="cid:image003.png@01D10B73.589A3220" xmlns:v="urn:schemas-microsoft-com:vml"/>
  </v:shape><![endif]--><![if !vml]>
                                    <img  border="0" height="32" src="img/devdv.png" v:shapes="Picture_x0020_3" width="32" /></span></p>
                            </td>
                            <td style="padding:.75pt 6.0pt 3.0pt 6.0pt" valign="top">
                                <p class="MsoNormal">
                                    <span style="font-size:9.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  color:green">Please consider your environmental responsibility. Before printing this slip, ask yourself whether you really need a hard copy.<o:p></o:p></span></p>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
