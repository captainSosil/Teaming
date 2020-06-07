<%@ Page Title="" Language="C#" MasterPageFile="~/DashBoard/DashBoardCore.Master" AutoEventWireup="true" CodeBehind="BusinessType.aspx.cs" Inherits="MemoEngine.BusinessType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <ol class="breadcrumb">
        <li class="breadcrumb-item active">제작자 소개</li>
        <!-- Breadcrumb Menu-->
        <li class="breadcrumb-menu d-md-down-none">
            <div class="btn-group" role="group" aria-label="Button group">
                <a class="btn" href="#">
                    <i class="icon-speech"></i>
                </a>
                <a class="btn" href="www.naver.com">
                    <i class="icon-graph"></i>Dashboard</a>
                <a class="btn" href="#">
                    <i class="icon-settings"></i>Settings</a>
            </div>
        </li>
    </ol>


    <div class="container-fluid">
        <div class="animated fadeIn">

             <div class="row">
              <div class="col-sm-6 col-md-4">
                <div class="card">
                  <div class="card-header">유형</div>
                  <div class="card-body">
                      내용
                  </div>
                </div>
              </div>
              <!-- /.col-->
              <div class="col-sm-6 col-md-4">
                <div class="card">
                  <div class="card-body">Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl
                    ut aliquip ex ea commodo consequat.</div>
                  <div class="card-footer">Card footer</div>
                </div>
              </div>
              <!-- /.col-->
              <div class="col-sm-6 col-md-4">
                <div class="card">
                  <div class="card-header">
                    <i class="fa fa-check"></i>Card with icon</div>
                  <div class="card-body">Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl
                    ut aliquip ex ea commodo consequat.</div>
                </div>
              </div>
              <!-- /.col-->
              <div class="col-sm-6 col-md-4">
                <div class="card">
                  <div class="card-header">Card with switch
                    <label class="switch switch-sm switch-text switch-info float-right mb-0">
                      <input class="switch-input" type="checkbox">
                      <span class="switch-label" data-on="On" data-off="Off"></span>
                      <span class="switch-handle"></span>
                    </label>
                  </div>
                  <div class="card-body">Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl
                    ut aliquip ex ea commodo consequat.</div>
                </div>
              </div>
             </div>


        </div>
    </div>

</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
