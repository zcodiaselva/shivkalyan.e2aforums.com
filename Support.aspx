<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="Support.aspx.cs" Inherits="_Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="support">
    <section class="hero js-browserHeight" id="support-hero">
      <div class="container text-center">
        <div class="row">
          <div class="large-12 column">
            <div class="info">
              <h2>Help &amp; Support</h2>
              <h1>We look forward to hearing from you!</h1>
              <p>Our friendly Support Team is available to help you 24 hours a day, seven days a week. We know you're busy, so we provide you with a number of options for you to contact us.</p>
            </div>
          </div>
        </div>
        <div class="row boxes boxes-support hide-for-small">
          <div class="col-md-3 column box">
            <div class="box-inner">
              <h4><a class="js-toggle-chat" href="#olark"><i class="fa fa-comment"></i> Chat Us</a></h4>
              <p>Someone from the e2aforums team is ready and available to chat and answer your questions round-the-clock.</p>
              <p><span id="MyLiveChatContainer"></span><span>→</span></p>
            </div>
          </div>
          <div class="col-md-3 column box">
            <div class="box-inner">
              <h4><a href="https://twitter.com/e2aforums"><i class="fa fa-twitter"></i> Tweet Us</a></h4>
              <p>Quick question? Tweet at us, and we'll get right back to you. Twitter's an excellent way to stay updated on e2aforums new feature releases.</p>
              <p><a href="https://twitter.com/e2aforums">Tweet at us →</a></p>
            </div>
          </div>
          <div class="col-md-3 column box">
            <div class="box-inner">
              <h4><a href="http://www.e2aforums.com/Support.aspx"><i class="fa fa-envelope-o"></i> Email us</a></h4>
              <p>If you’re encountering an issue or problem when working with E2aForums, you can always email us directly or via the form below.</p>
              <p><a href="mailto:support@e2aforums.com">Email Support →</a></p>
            </div>
          </div>
          <div class="col-md-3 column box">
            <div class="box-inner">
              <h4><a href="tel: +1 (888)-280-7780"><i class="fa fa-phone"></i> Call us</a></h4>
              <p>We're available on phone round-the-clock and you may call us if it's just easier to talk regarding an issue or concern.</p>
              <p><a href="tel:+1-888-280-7780">Call at +1 (888)-280-7780</a></p>
            </div>
          </div>
        </div>
      </div>
    </section>
    <!-- /.hero -->
    
    <section class="content content-support">
      <div class="container">
        <div class="large-10 large-centered column">
          <h2>Drop us a line.</h2>
          <p>If you're an existing user of e2aforums and experiencing trouble or have a question before signing up, drop us a line below and we'll help you out. </p>
          <div id="wpcf7-f287-p144-o1" class="wpcf7">
            <form id="Form1" novalidate="novalidate" runat="server" class="wpcf7-form" method="post" action="#">
              <asp:ScriptManager ID="ScriptManager2" runat="server"> </asp:ScriptManager>
              <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <div class="row">
                    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor = "Green"></asp:Label>
                    <div class="col-md-6 column">
                      <div class="form-group">
                        <label> Name *</label>
                        <span class="">
                        <%--<input type="text" aria-required="true" class="form-control" size="40" value="" name="name">--%>
                        <asp:TextBox runat="server" ID="txtName" type="text" aria-required="true" class="form-control" size="40" value="" name="name" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="error-msg" runat="server" ErrorMessage="* Name is required."  ForeColor="Red"
             ControlToValidate = "txtName"></asp:RequiredFieldValidator>
                        </span> </div>
                      <div class="form-group">
                        <label>Email *</label>
                        <span class="">
                        <%--  <input type="email" aria-required="true" class="form-control" size="40" value="" name="email">--%>
                        <asp:TextBox runat="server" ID="txtEmail" type="email" aria-required="true" class="form-control" size="40" value="" name="email" ></asp:TextBox>
                        <asp:RegularExpressionValidator id="valRegEx" CssClass="error-msg" runat="server" ControlToValidate="txtEmail" ForeColor="Red" ValidationExpression=".*@.*\..*" ErrorMessage="* Invalid Email address." display="dynamic"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="error-msg" runat="server" ErrorMessage="* Email is required."  ForeColor="Red" ControlToValidate = "txtEmail"></asp:RequiredFieldValidator>
                        </span> </div>
                      <div class="form-group">
                        <label>Phone *</label>
                        <span class="">
                        <%--<input type="tel" class="form-control" size="40" value="" name="phone">--%>
                        <asp:TextBox runat="server"  ID="txtPhone" type="tel" class="form-control" size="40" value="" name="phone" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="error-msg" runat="server" ErrorMessage="* Phone no. is required." ForeColor="Red" ControlToValidate = "txtPhone"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator id="RegularExpressionValidator1" CssClass="error-msg" ControlToValidate="txtPhone" ForeColor="Red" ValidationExpression="\d+" Display="Static" EnableClientScript="true" ErrorMessage="* Please enter numbers only" runat="server"/>
                        </span> </div>
                      <div class="form-group">
                        <label>Company Name *</label>
                        <span class="">
                        <%--<input type="text" class="form-control" size="40" value="" name="company">--%>
                        <asp:TextBox runat="server"  ID="txtCompanyName" type="tel" class="form-control" size="40" value="" name="company"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="error-msg" runat="server" ErrorMessage="* Company name is required." ForeColor="Red" ControlToValidate = "txtCompanyName"></asp:RequiredFieldValidator>
                        </span> </div>
                    </div>
                    <div class="col-md-6 column">
                      <div class="form-group">
                        <label>Subject *</label>
                        <span class="">
                        <asp:TextBox ID="txtSubject" runat="server"  class="form-control" size="40" value="" name="company"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="error-msg" runat="server" ErrorMessage="* Subject is required." ForeColor="Red" ControlToValidate = "txtSubject"></asp:RequiredFieldValidator>
                        </span> </div>
                      <div class="form-group">
                        <label>Message *</label>
                        <span class="wpcf7-form-control-wrap message">
                        <%-- <textarea aria-required="true" class="form-control" rows="10" cols="40" name="message"></textarea>--%>
                        <asp:TextBox ID="txtmessage" class="form-control" runat="server" TextMode = "MultiLine" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="error-msg" runat="server" ErrorMessage="* Message is required." ForeColor="Red" ControlToValidate = "txtmessage"></asp:RequiredFieldValidator>
                        </span> </div>
                    </div>
                  </div>
                  <div class="row text-center">
                    <asp:Button ID="btnSend" runat="server" Text="Send" class="wpcf7-form-control wpcf7-submit btn btn-large btn-violet" OnClick="btnSend_Click" />
                  </div>
                  <div class="wpcf7-response-output wpcf7-display-none" style="display: none;"></div>
                </ContentTemplate>
              </asp:UpdatePanel>
            </form>
          </div>
        </div>
      </div>
    </section>
  </div>
  <script type="text/javascript" async="async" defer="defer" data-cfasync="false" src="https://mylivechat.com/chatlink.aspx?hccid=37443139"></script> 
</asp:Content>
