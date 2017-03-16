<!-- Main header-->
<?php include('header.php');?>
<!-- end main header-->

<!-- Top header -->
<?php include('topheader.php');?>
<!-- End top header-->

<!-- Main sidebar-->
<?php include('mainsidebar.php');?>
<!-- End sb -->
<!-- Content Wrapper. Contains page content -->
      <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <ol class="breadcrumb" style="position:relative;">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li class="active">Dashboard</li>
          </ol>
          <div style="clear:both"></div>
        </section>

        <!-- Main content -->
        <section class="content">
          <!-- Info boxes -->
          <div class="row">
            
            <!-- fix for small devices only -->
            <div class="clearfix visible-sm-block"></div>

            <div class="col-md-3 col-sm-6 col-xs-12">
              <div class="info-box">
                <span class="info-box-icon bg-yellow"><i class="ion ion-ios-people-outline"></i></span>
                <div class="info-box-content">
                  <span class="info-box-text">Customers</span>
                  <span class="info-box-number">2,000</span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div><!-- /.col -->
            
            <div class="col-md-3 col-sm-6 col-xs-12">
              <div class="info-box">
                <span class="info-box-icon bg-green"><i class="fa fa-tint"></i></span>
                <div class="info-box-content">
                  <span class="info-box-text">Drivers</span>
                  <span class="info-box-number">3,000</span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div><!-- /.col -->
            
            <div class="col-md-3 col-sm-6 col-xs-12">
              <div class="info-box">
                <span class="info-box-icon bg-red"><i class="fa fa-users"></i></span>
                <div class="info-box-content">
                  <span class="info-box-text">Employees</span>
                  <span class="info-box-number">4,100</span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div><!-- /.col -->
            
            <div class="col-md-3 col-sm-6 col-xs-12">
              <div class="info-box">
                <span class="info-box-icon bg-aqua"><i class="ion ion-ios-gear-outline"></i></span>
                <div class="info-box-content">
                  <span class="info-box-text">Suppliers</span>
                  <span class="info-box-number">10,000</span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div><!-- /.col -->
            
            
          </div><!-- /.row -->

          <div class="row">
            <div class="col-md-12">
              <div class="box box-warning">
                <div class="box-header with-border">
                  <h3 class="box-title">Monthly Recap Report</h3>
                  <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <div class="btn-group">
                      <button class="btn btn-box-tool dropdown-toggle" data-toggle="dropdown"><i class="fa fa-wrench"></i></button>
                      <ul class="dropdown-menu" role="menu">
                        <li><a href="#">Action</a></li>
                        <li><a href="#">Another action</a></li>
                        <li><a href="#">Something else here</a></li>
                        <li class="divider"></li>
                        <li><a href="#">Separated link</a></li>
                      </ul>
                    </div>
                    <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                  </div>
                </div><!-- /.box-header -->
                <div class="box-body">
                  <div class="row">
                    <div class="col-md-8">
                      <p class="text-center">
                        <strong>Sales: 1 Jan, 2016 - 30 Jul, 2016</strong>
                      </p>
                      <div class="chart">
                        <!-- Sales Chart Canvas -->
                        <canvas id="salesChart" style="height: 180px;"></canvas>
                      </div><!-- /.chart-responsive -->
                    </div><!-- /.col -->
                    <div class="col-md-4">
                      <p class="text-center">
                        <strong>Goal Completion</strong>
                      </p>
                      <div class="progress-group">
                        <span class="progress-text">Suppliers</span>
                        <span class="progress-number"><b>160</b>/200</span>
                        <div class="progress sm">
                          <div class="progress-bar progress-bar-aqua" style="width: 80%"></div>
                        </div>
                      </div><!-- /.progress-group -->
                      <div class="progress-group">
                        <span class="progress-text">Employees</span>
                        <span class="progress-number"><b>310</b>/400</span>
                        <div class="progress sm">
                          <div class="progress-bar progress-bar-red" style="width: 80%"></div>
                        </div>
                      </div><!-- /.progress-group -->
                      <div class="progress-group">
                        <span class="progress-text">Oil Sales</span>
                        <span class="progress-number"><b>480</b>/800</span>
                        <div class="progress sm">
                          <div class="progress-bar progress-bar-green" style="width: 80%"></div>
                        </div>
                      </div><!-- /.progress-group -->
                      <div class="progress-group">
                        <span class="progress-text">Customers</span>
                        <span class="progress-number"><b>250</b>/500</span>
                        <div class="progress sm">
                          <div class="progress-bar progress-bar-yellow" style="width: 80%"></div>
                        </div>
                      </div><!-- /.progress-group -->
                    </div><!-- /.col -->
                  </div><!-- /.row -->
                </div><!-- ./box-body -->
                <div class="box-footer">
                  <div class="row">
                    <div class="col-sm-3 col-xs-6">
                      <div class="description-block border-right">
                        <span class="description-percentage text-green"><i class="fa fa-caret-up"></i> 17%</span>
                        <h5 class="description-header">$35,210.43</h5>
                        <span class="description-text">TOTAL REVENUE</span>
                      </div><!-- /.description-block -->
                    </div><!-- /.col -->
                    <div class="col-sm-3 col-xs-6">
                      <div class="description-block border-right">
                        <span class="description-percentage text-yellow"><i class="fa fa-caret-left"></i> 0%</span>
                        <h5 class="description-header">$10,390.90</h5>
                        <span class="description-text">TOTAL COST</span>
                      </div><!-- /.description-block -->
                    </div><!-- /.col -->
                    <div class="col-sm-3 col-xs-6">
                      <div class="description-block border-right">
                        <span class="description-percentage text-green"><i class="fa fa-caret-up"></i> 20%</span>
                        <h5 class="description-header">$24,813.53</h5>
                        <span class="description-text">TOTAL PROFIT</span>
                      </div><!-- /.description-block -->
                    </div><!-- /.col -->
                    <div class="col-sm-3 col-xs-6">
                      <div class="description-block">
                        <span class="description-percentage text-red"><i class="fa fa-caret-down"></i> 18%</span>
                        <h5 class="description-header">1200</h5>
                        <span class="description-text">GOAL COMPLETIONS</span>
                      </div><!-- /.description-block -->
                    </div>
                  </div><!-- /.row -->
                </div><!-- /.box-footer -->
              </div><!-- /.box -->
            </div><!-- /.col -->
          </div><!-- /.row -->

          <!-- Main row -->
          <div class="row">
            <!-- Left col -->
            <div class="col-md-6">
              <!-- TABLE: LATEST ORDERS -->
              <div class="box box-success">
                <div class="box-header with-border">
                  <h3 class="box-title">Milling Orders</h3>
                  <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                  </div>
                </div><!-- /.box-header -->
                <div class="box-body">
                  <div class="table-responsive">
                    <table class="table no-margin">
                      <thead>
                        <tr>
                          <th>Order ID</th>
                          <th>Customer Name</th>
                          <th>Status</th>
                        </tr>
                      </thead>
                      <tbody>
                        <tr>
                          <td><a href="pages/examples/invoice.html">OR9842</a></td>
                          <td>Order name</td>
                          <td><span class="label label-success">Completed</span></td>
                        </tr>
                        <tr>
                          <td><a href="pages/examples/invoice.html">OR1848</a></td>
                          <td>Order name</td>
                          <td><span class="label label-warning">Processing</span></td>
                        </tr>
                        <tr>
                          <td><a href="pages/examples/invoice.html">OR7429</a></td>
                          <td>Order name</td>
                          <td><span class="label label-danger">Pending</span></td>
                        </tr>
                        <tr>
                          <td><a href="pages/examples/invoice.html">OR7429</a></td>
                          <td>Order name</td>
                          <td><span class="label label-success">Completed</span></td>
                        </tr>
                        <tr>
                          <td><a href="pages/examples/invoice.html">OR1848</a></td>
                          <td>Order name</td>
                          <td><span class="label label-warning">Processing</span></td>
                        </tr>
                        <tr>
                          <td><a href="pages/examples/invoice.html">OR7429</a></td>
                          <td>Order name</td>
                          <td><span class="label label-danger">Pending</span></td>
                        </tr>
                      </tbody>
                    </table>
                  </div><!-- /.table-responsive -->
                </div><!-- /.box-body -->
                <div class="box-footer clearfix">
                  <a href="#" class="btn btn-sm btn-warning btn-flat pull-left">Add Ticket</a>
                  <a href="#" class="btn btn-sm btn-warning btn-flat pull-right">View All Orders</a>
                </div><!-- /.box-footer -->
              </div><!-- /.box -->
            </div><!-- /.col -->

            <div class="col-md-6 connectedSortable">
              	<div class="nav-tabs-custom">
                <!-- Tabs within a box -->
                <ul class="nav nav-tabs pull-right">
                  <li><a href="#total-order" data-toggle="tab">Total</a></li>
                  <li class="active"><a href="#daily-order" data-toggle="tab">Daily</a></li>
                  <li class="pull-left header"><i class="fa fa-inbox"></i> Order Summary</li>
                </ul>
                <div class="tab-content no-padding">
                  <!-- Morris chart - Sales -->
                  <div id="daily-order" class="chart tab-pane active" style="position: relative; height: 330px;">
                  	<div class="col-md-6">
                    	<table class="table table-bordered">
                    <tr>
                      <td>Queue Number</td>
                      <td>550</td>
                    </tr>
                    <tr>
                      <td>Processed Order</td>
                      <td>400</td>
                    </tr>
                    <tr>
                      <td>Olive Milled</td>
                      <td>1300kg</td>
                    </tr>
                    <tr>
                      <td>Oil Produced</td>
                      <td>200kg</td>
                    </tr>
                    <tr>
                      <td>In kind oil</td>
                      <td>100kg</td>
                    </tr>
                    <tr>
                      <td>Cash oil milling</td>
                      <td>2000 JOD</td>
                    </tr>
                    <tr>
                      <td>In kind Olives</td>
                      <td>300kg</td>
                    </tr>
                  </table>
                    </div>
                    <div class="col-md-6">
                    	<table class="table table-bordered">
                    <tr>
                      <td>Oil Sale</td>
                      <td>1000 JOD</td>
                    </tr>
                    <tr>
                      <td>Pomac Sale</td>
                      <td>300 JOD</td>
                    </tr>
                    <tr>
                      <td>Large Cane</td>
                      <td>50 Cane</td>
                    </tr>
                    <tr>
                      <td>Small Cane</td>
                      <td>70 Cane</td>
                    </tr>
                    <tr>
                      <td>Revenue</td>
                      <td>600 JODs</td>
                    </tr>
                    <tr>
                      <td>Cost</td>
                      <td>250 JODs</td>
                    </tr>
                    <tr>
                      <td>Gross Profit</td>
                      <td>350 JODs</td>
                    </tr>
                  </table>
                    </div>
                  </div>
                  <div id="total-order" class="chart tab-pane" style="position: relative; height: 330px;">
                  	<div class="col-md-6">
                    	<table class="table table-bordered">
                    <tr>
                      <td>Queue Number</td>
                      <td>550</td>
                    </tr>
                    <tr>
                      <td>Processed Order</td>
                      <td>400</td>
                    </tr>
                    <tr>
                      <td>Olive Milled</td>
                      <td>1300kg</td>
                    </tr>
                    <tr>
                      <td>Oil Produced</td>
                      <td>200kg</td>
                    </tr>
                    <tr>
                      <td>In kind oil</td>
                      <td>100kg</td>
                    </tr>
                    <tr>
                      <td>Cash oil milling</td>
                      <td>2000 JOD</td>
                    </tr>
                    <tr>
                      <td>In kind Olives</td>
                      <td>300kg</td>
                    </tr>
                  </table>
                    </div>
                    <div class="col-md-6">
                    	<table class="table table-bordered">
                    <tr>
                      <td>Queue Number</td>
                      <td>550</td>
                    </tr>
                    <tr>
                      <td>Processed Order</td>
                      <td>400</td>
                    </tr>
                    <tr>
                      <td>Olive Milled</td>
                      <td>1300kg</td>
                    </tr>
                    <tr>
                      <td>Oil Produced</td>
                      <td>200kg</td>
                    </tr>
                    <tr>
                      <td>In kind oil</td>
                      <td>100kg</td>
                    </tr>
                    <tr>
                      <td>Cash oil milling</td>
                      <td>2000 JOD</td>
                    </tr>
                    <tr>
                      <td>In kind Olives</td>
                      <td>300kg</td>
                    </tr>
                  </table>
                    </div>
                  </div>
                </div>
              </div>
            </div><!-- /.col -->
            
          </div><!-- /.row -->
        </section><!-- /.content -->
      </div><!-- /.content-wrapper -->
      
<!-- #footer -->
<?php include('footer.php');?>
