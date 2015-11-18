<!-- store.tpl -->
<!-- Store Documents popup -->

<!-- Author: Jimmy Swanbeck -->
<!-- Endicott College -->
<!-- 1/2/15 -->

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
  <title>Store Documents</title>
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
<body onload="loadPopup(800, 710)">
  <div class="container">
      
    <!-- Top row (title) -->
    <div class="row">
      <div class="twelve columns">
        <h4 style="margin-bottom: 0">Store Documents</h4>
      </div>
    </div>

    <!-- First row (toolbar) -->
    <div class="row">

      <!-- Store Documents -->
      <div class="four columns linkButton">
        <form action="store" style="margin-bottom: .9rem">
          <input type="submit" style="width: 100%; margin-bottom: 0" value="Store Documents">
        </form>
      </div>

      <!-- View Documents -->
      <div class="four columns linkButton">
        <form action="view" style="margin-bottom: .9rem">
          <input type="submit" style="width: 100%; margin-bottom: 0" value="View Documents">
        </form>
      </div>

      <!-- Search Documents -->
      <div id="btnSearchDocuments" class="four columns linkButton">
        <form action="search" style="margin-bottom: .9rem">
          <input type="submit" style="width: 100%; margin-bottom: 0" value="Search Documents">
        </form>
      </div>

    </div>

    <!-- Second row (tool content)-->
    <div class="row">
      <div class="twelve columns" style="margin-top: .2rem">
        <form action="" style="margin-bottom: 0" method="POST"> <!-- Content form (POST) -->
          <input id="txtRecipients" type="text" name="recipients" placeholder="Recipients (separated by spaces)" style="width: 100%; {{recipientsStyle}}" onkeyup="valid(this)"><br>  <!-- Recipients textbox -->
          <input type="text" name="subject" placeholder="Subject" style="width: 100%" value="{{subject}}"><br>  <!-- Subject textbox -->
          <textarea name="body" style="width: 100%; height: 270px; resize: none">{{body}}</textarea><br>  <!-- Body textbox -->
          <input type="submit" formaction="store" class="actionButton" value="Submit"> <!-- Submit button -->
        </form>
      </div>
    </div>

    <!-- Bottom row (author) -->
    <div class="row">
      <div id="copyright" class="twelve columns" style="margin-top: 0">
        <p id="copyright">By Jimmy Swanbeck - Endicott College 2015</p>
      </div>
    </div>

  </div>
</body>
</html>
