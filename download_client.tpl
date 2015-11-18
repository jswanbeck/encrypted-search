<!-- download_client.tpl -->
<!-- Download Client popup -->

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
  <title>Download Client</title>
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
      
    <!-- Top row (title) -->
    <div class="row">
      <div class="twelve columns">
        <h4 style="margin-bottom: 0">Download Client</h4>
      </div>
    </div>

    <!-- First row (download for Windows) -->
    <div class="row" style="margin: 0">
      <div class="twelve columns" style="margin: 0">
        <form action="/static/algorithms.pdf" target="_blank" onclick="downloadClient(0)" style="margin-bottom: 0">
          <input type="button" style="width: 100%; margin-bottom: 0" value="Download for Windows">
        </form>
      </div>
    </div>

    <!-- Second row (download for Mac) -->
    <div class="row" style="margin: 0">
      <div class="twelve columns" style="margin: 0">
        <form action="" target="_blank" onclick="downloadClient(1)" style="margin-bottom: 0">
          <input type="button" style="width: 100%; margin-bottom: 0" value="Download for Mac">
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
