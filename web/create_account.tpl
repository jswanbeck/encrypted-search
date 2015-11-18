<!-- login.tpl -->
<!-- Login popup -->

<!-- Author: Jimmy Swanbeck -->
<!-- Endicott College -->
<!-- 1/7/15 -->

<!-- This template contributes to the view layer of the web application:
          Creates an HTML page
          Loads that page with images, font, CSS, and Javascript -->

<!DOCTYPE html>
<html lang="en">
<head>

<!-- Javascript -->
<script type="text/javascript" src="static/master.js" charset="utf-8"></script>

  <!-- Page Info -->
  <meta charset="utf-8">
  <title>Create Account</title>
  <meta name="description" content="Encrypted search senior thesis (2015)">
  <meta name="author" content="Jimmy Swanbeck">

  <!-- Images -->
  <link rel="icon" type="image/png" href="static/favicon.png">

  <!-- Font -->
  <link href="//fonts.googleapis.com/css?family=Raleway:400,300,600" rel="stylesheet" type="text/css">

  <!-- CSS -->
  <link rel="stylesheet" href="static/normalize.css">
  <link rel="stylesheet" href="static/skeleton.css">
  <link rel="stylesheet" href="static/base.css">

</head>
<body onload="loadPopup(450, 260)">
  <div class="container">

    <!-- Top row (logo) -->
    <div class="row">
      <div id="logo" class="twelve columns" style="text-align: center">
        <a href="/index"><img style="width: 70%" src="static/logo.png"></a>
      </div>
    </div>
      
    <!-- First row (title) -->
    <div class="row">
      <div class="twelve columns" style="margin-left: 25%">
        <h4 style="margin-bottom: 0; {{messageStyle}}">{{message}}</h4>
      </div>
    </div>

    <!-- Second row (textboxes, buttons, author) -->
    <div class="row">
      <div class="twelve columns" style="margin-top: .2rem; margin-left: 25%; width: 50%">
        <form action="" style="margin-bottom: 0; text-align: center" method="POST">
          <input id="txtUsername" type="text" name="username" placeholder="Username" style="width: 100%; {{usernameStyle}}" value="{{username}}"><br>
          <input id="txtPassword" type="password" name="password" placeholder="Password" style="width: 100%; {{passwordStyle}}" value="{{password}}"><br>
          <input id="txtEmail" type="text" name="email" placeholder="Email" style="width: 100%; {{emailStyle}}" value="{{email}}"><br>
          <input type="submit" formaction="create_account" style="width: 100%; margin-bottom: 1.5rem" value="Create Account">
        </form>
        <p id="copyright">By Jimmy Swanbeck - Endicott College 2015</p>
      </div>
    </div>

  </div>
</body>
</html>
