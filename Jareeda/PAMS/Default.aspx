<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PAMS.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="/App_Themes/PAMS/1_normalize.css" rel="stylesheet" />
    <link href="/App_Themes/PAMS/bootstrap/2_bootstrap.css" rel="stylesheet" />
    <link href="/App_Themes/PAMS/3_Style.css" rel="stylesheet" />
    <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
  <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
<![endif]-->
</head>
<body screen_capture_injected="true">

    <form id="form1" runat="server">
        <header class="header">
            <div class="topbar graybar">
                <div class="container">
                    <a class="pull-right" href="#">Log in</a>
                </div>
            </div>
            <div class="container">
                <div class="navbar-header">
                    <button class="navbar-toggle" type="button" data-toggle="collapse" data-target=".bs-navbar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a href="../" class="navbar-brand">
                        <img src="/App_Themes/PAMS/images/logo/logo-icon.png" width="32" style="margin-top: -5px;" />
                        esperto</a>
                </div>
                <nav class="collapse navbar-collapse bs-navbar-collapse" role="navigation">
                    <ul class="nav navbar-nav">
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li class="active">
                            <a href="../getting-started">Features</a>
                        </li>
                        <li>
                            <a href="../css">Agent</a>
                        </li>
                        <li>
                            <a href="../components">Principle</a>
                        </li>
                        <li>
                            <a href="../javascript">Prices</a>
                        </li>
                        <li class="btn selected-red">
                            <a href="../about">Try It Free</a>
                        </li>
                    </ul>
                </nav>
            </div>
        </header>

        <section id="area" class="main-area">
            <%--<div id="carousel-example-generic" class="carousel slide area" data-ride="carousel">
                <ol class="carousel-indicators">
                    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                </ol>
                <div class="container carousel-inner">
                    <div class="item active">
                        <h1 style="font-size: 65.55555555555556px;">Designed &amp; Developed for Agents, Principles & Traders.</h1>
                        <div class="team">
                            <div>
                                <img src="App_Themes/PAMS/images/team.png" />
                            </div>
                        </div>
                    </div>

                    <div class="item">
                        <h1 style="font-size: 65.55555555555556px;">Designed &amp; Developed for Agents, Principles & Traders.</h1>
                        <div class="team">
                            <div>
                                <img src="App_Themes/PAMS/images/team.png" />
                            </div>
                        </div>
                    </div>

                    <div class="item">
                        <h1 style="font-size: 65.55555555555556px;">Designed &amp; Developed for Agents, Principles & Traders.</h1>
                        <div class="team">
                            <div>
                                <img src="App_Themes/PAMS/images/team.png" />
                            </div>
                        </div>
                    </div>

                </div>
                <!-- Controls -->
                <a class="left carousel-control" href="#carousel-example-generic" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left"></span>
                </a>
                <a class="right carousel-control" href="#carousel-example-generic" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right"></span>
                </a>
            </div>--%>

            <div id="box-main-carousal" class="row carousel fade box-main" data-ride="carousel" data-interval="8000" data-wrap="true">
                <ol class="carousel-indicators">
                    <li data-target="#box-main-carousal" data-slide-to="0"></li>
                    <li data-target="#box-main-carousal" data-slide-to="1" class="active"></li>
                    <li data-target="#box-main-carousal" data-slide-to="2"></li>
                </ol>

                <div class="carousel-inner">
                    <div class="item box-item" style="background-image: url('/Assets/images/bg07.jpg'); background-position: 50% 0%; background-repeat: repeat no-repeat;">
                        <div class="container">
                            <div class="col-md-5">
                                <h1 style="color: #fff;">Enterprise Agent Management System</h1>
                                <p style="font-weight: bold;">
                                    Managing your jobs has never been easier, with esperto you'll experience the power of being in control 
                                </p>
                                <a href="#" style="margin-top: 40px;" class="btn btn-primary btn-primary-big pull-right">Features Overview</a>
                            </div>
                            <div class="col-md-5">
                                <img src="Assets/images/nm_full_1-m.png" />
                            </div>
                        </div>
                    </div>
                    <div class="item box-item active">
                        <div class="container">
                            <h1 style="font-size: 65.55555555555556px;">Enterprise Agent Management Solution</h1>
                            <img src="App_Themes/PAMS/images/team.png" class="img-responsive" />
                        </div>
                    </div>
                    <div class="item box-item" style="background-image: url('/Assets/images/bg06.png'); background-position: 50% 0%; background-repeat: repeat no-repeat;">
                        <div class="container">
                            <h1 style="font-size: 65.55555555555556px; color: #fff;">Amazing Features</h1>
                            <div class="box-card grow-in">
                                <div class="card-img">
                                    <img src="/Assets/images/dashboard.png" />
                                </div>
                                <h4>Dashboard
                                </h4>
                                <p>
                                    amazing features that rocks you'll be amazed some extra text
                                </p>
                                <div class="starred">
                                    <img src="/Assets/images/starred.png" width="32" />
                                </div>
                            </div>
                            <div class="box-card grow-in">
                                <div class="card-img">
                                    <img src="/Assets/images/innter-image.png" />
                                </div>
                                <h4>Calculation Sheet
                                </h4>
                                <p>
                                    amazing features that rocks you'll be amazed some extra text
                                </p>
                                <div class="starred">
                                    <img src="/Assets/images/starred.png" width="32" />
                                </div>
                            </div>
                            <div class="box-card grow-in">
                                <div class="card-img">
                                    <img src="/Assets/images/innter-image.png" />
                                </div>
                                <h4>Document Support
                                </h4>
                                <p>
                                    amazing features that rocks you'll be amazed some extra text
                                </p>
                                <div class="starred">
                                    <img src="/Assets/images/starred.png" width="32" />
                                </div>
                            </div>
                            <div class="box-card grow-in">
                                <div class="card-img">
                                    <img src="/Assets/images/innter-image.png" />
                                </div>
                                <h4>Report Building
                                </h4>
                                <p>
                                    amazing features that rocks you'll be amazed some extra text
                                </p>
                                <div class="starred">
                                    <img src="/Assets/images/starred.png" width="32" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <a class="left carousel-control" href="#box-main-carousal" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left"></span>
                </a>
                <a class="right carousel-control" href="#box-main-carousal" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right"></span>
                </a>
            </div>

            <div class="container major-section">
                <div class="row">
                    <div class="col-md-7">
                        <p class="intro">
                            Solutions which intuitively fit like a hand in a glove. No one has to tell you how to use a glove, because its shape fits perfectly with that of the hand. The wearer intuitively guides their fingers into the form of the glove.
                        </p>
                        <header>
                            <h2>Stress free solutions 
                            </h2>
                        </header>
                        <p>
                            Solutions which intuitively fit like a hand in a glove. No one has to tell you how to use a glove, because its shape fits perfectly with that of the hand. The wearer intuitively guides their fingers into the form of the glove.
                        </p>
                    </div>
                    <div class="col-md-4 pull-right">
                        <h2>What our customers say ?</h2>
                        <figure class="blockquote--bubble blockquote--has-source">
                            <blockquote>
                                esperto innovative design solution helped us reduce the average handling time for customer enquiries by <mark>up&nbsp;to&nbsp;75&nbsp;%</mark>.
                            </blockquote>
                            <figcaption>Sebastian Reiner
							<small>Project Manager Customer Service &amp; Sales, <a href="http://a1.net" target="_blank" title="A1 Telekom Austria website">A1 Telekom Austria</a></small>
                            </figcaption>
                        </figure>
                    </div>
                </div>


            </div>
            <div class="row two metatrails-hero space">
                <div class="container">
                    <div class="jct  grow-in">
                        <h1 style="opacity:0;" class="grow-in">What is esperto* </h1>
                        <img src="Assets/images/guarantee.png" />
                    </div>
                </div>
            </div>
        </section>

        <footer class="footer">
            <div class="container footer-image">
                <h1>esparto makes your life that bit <mark>easier</mark></h1>
                <br />
                <a href="../about" class="btn btn-primary btn-primary-red">Order esperto</a>
            </div>
        </footer>


    </form>

    <script src="Assets/JS/jquery-1.10.2.min.js"></script>
    <script src="Assets/JS/bootstrap.min.js"></script>
</body>
</html>
