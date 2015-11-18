<!-- index.tpl -->
<!-- The homepage for the web application -->

<!-- Author: Jimmy Swanbeck -->
<!-- Endicott College -->
<!-- 12/30/14 -->

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
  <title>Encrypted Search</title>
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
<body onload="loadIndex()">
  <div class="container">

    <!-- Top row (logo) -->
    <div class="row">
      <div id="logo" class="twelve columns" style="text-align: center">
        <a href="/index"><img style="width: 70%" src="static/logo.png"></a>
      </div>
    </div>
      
    <!-- First row (menu buttons)-->
    <div class="row">

      <!-- Login -->
      <div class="two columns linkButton menuLink">
        <form action="/login" style="margin-bottom: .9rem">
          <input type="submit" style="width: 100%; margin-bottom: 0" value="{{btnLoginText}}">
        </form>
      </div>
      <!-- <div class="two columns linkButton menuLink">
        <button type="button" onclick="popupWindow('/login','Login', 550, 310)" style="width: 100%; margin-bottom: 0">Login</button>
      </div> -->

      <!-- Create Account -->
      <div class="two columns linkButton menuLink">
        <form action="/create_account" style="margin-bottom: .9rem">
          <input type="submit" style="width: 100%; margin-bottom: 0" value="Create Account">
        </form>
      </div>
      <!-- <div class="two columns linkButton menuLink">
        <button type="button" onclick="popupWindow('/create_account','Create Account', 550, 370)" style="width: 100%; margin-bottom: 0">Create Account</button>
      </div> -->

      <!-- Download Client -->
      <div class="two columns linkButton menuLink">
        <button type="button" onclick="popupWindow('/download_client','Download Client', 450, 240)" style="width: 100%; margin-bottom: 0">Download Client</button>
      </div>

      <!-- Algorithms -->
      <div class="two columns linkButton menuLink">
        <form action="/static/algorithms.pdf" target="_blank" style="margin-bottom: .9rem">
          <input type="submit" style="width: 100%; margin-bottom: 0" value="Algorithms">
        </form>
      </div>

      <!-- Thesis Paper -->
      <div class="two columns linkButton menuLink">
        <form action="/static/encrypted_search_document.pdf" target="_blank" style="margin-bottom: .9rem">
          <input type="submit" style="width: 100%; margin-bottom: 0" value="Thesis Paper">
        </form>
      </div>

      <!-- Thesis Powerpoint -->
      <div id="colPowerpoint" class="two columns linkButton menuLink">
        <form action="/static/encrypted_search_presentation.pdf" target="_blank" style="margin-bottom: .9rem">
          <input type="submit" style="width: 100%; margin-bottom: 0" value="Thesis Powerpoint">
        </form>
      </div>

    </div>

    <!-- Second row (username, thesis description, toolbar) -->
    <div class="row">

      <!-- Encrypted Search -->
      <div id="colEncryptedSearch" class="nine columns" style="outline: black thin solid">
        <p style="float: right; padding: .7% 4% .5%; text-align: right; background-color: {{usernameColor}}; border: solid 1px; border-radius: 4px">{{username}}</p>
        <h4>Encrypted Search</h4>
        <p style="margin-bottom: .5rem">Welcome to Jimmy Swanbeck's senior thesis project. The goal of this project is to investigate how to make encrypted search compatible with a cloud server. By using the tools listed on the right, you can store, view, and search through documents in the database. However, all encryption must happen from the client side and anything done via this web interface is happening directly on the server (for a full explanation see the <a href="/static/encrypted_search_document.pdf" target="_blank">paper</a> and <a href="/static/encrypted_search_presentation.pdf" target="_blank">powerpoint presentation</a>). To perform these actions on encrypted data, download the client.</p>
      </div>

      <!-- Document Tools -->
      <div id="colButtons" class="three columns">
        <h4 style="text-align: center">Tools</h4>

        <!-- Store Documents -->
        <button id="btnStore" type="button" onclick="popupWindow('/store','Store Documents', 800, 700)" style="width: 100%">Store Documents</button>

        <!-- View Documents -->
        <button id="btnView" type="button" onclick="popupWindow('/view','View Documents', 800, 700)" style="width: 100%">View Documents</button>

        <!-- Search Documents -->
        <button id="btnSearch" type="button" onclick="popupWindow('/search','Search Documents', 800, 700)" style="width: 100%">Search Documents</button>

      </div>

    </div>
      
    <!-- Third row (tool descriptions) -->
    <div class="row">

      <!-- Store Documents -->
      <div id="colStoreDocuments" class="four columns" style="outline: black thin solid">
        <h4 id="hStore">Store Documents</h4>
        <p id="pStore" style="margin-bottom: .5rem">This function will allow you to create documents (in the form of mock emails) and store them on the server in a MySQL database. Note that anything stored in this way is being done without encryption; all encryption must happen on the client side, so documents created this way will be stored in plaintext.</p>
      </div>

      <!-- View Documents -->
      <div id="colViewDocuments" class="four columns" style="outline: black thin solid">
        <h4 id="hView">View Documents</h4>
        <p id="pView" style="margin-bottom: .5rem">This function will allow you to view the encrypted documents as they're stored on the server. Note that anything viewed in this format will not be decrypted and you will essentially see what a hacker would see. This is the equivalent of viewing files directly on the server; all decryption must be done from the client side.</p>
      </div>

      <!-- Search Documents -->
      <div id="colSearchDocuments" class="four columns" style="outline: black thin solid">
        <h4 id="hSearch">Search Documents</h4>
        <p id="pSearch" style="margin-bottom: .5rem">This function will allow you to search through the encrypted documents and return a match based on our search algorithms (a detailed assessment of which can be found <a href="/static/algorithms.pdf" target="_blank">here</a>). This will retrieve documents directly from the server, meaning that encrypted files created using the client will be unreadable.</p>
      </div>

    </div>

    <!-- Bottom row (author) -->
    <div class="row">
      <div id="copyright" class="twelve columns">
        <p id="copyright">By Jimmy Swanbeck - Endicott College 2015</p>
      </div>
    </div>

  </div>
</body>
</html>
