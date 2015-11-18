#!/usr/bin/env python

# master.py
# The main script to be run, containing all routing information about the web application

# Author: Jimmy Swanbeck
# Endicott College
# 12/30/14

# This python script handles the controller layer of the web application:
#		Routes pages/files, serving information to the view layer
# 		Performs operations on information in the MySQL database, communicating with the model layer
#		Runs the Apache web server
#		Listens for connections on a port & IP address

# MODULES
from bottle import route, run, template, static_file, request, get, post
import bottle
import bottle_session
import MySQLdb
import re
import hashlib
import uuid

# PLUGINS
app = bottle.app()
plugin = bottle_session.SessionPlugin(cookie_lifetime=600, host='0.0.0.0', port=8080, keyword='session')
app.install(plugin)

# METHODS
# Create a normalized, searchable index
def generate_search_index(text):
	search_index = []
	for word in text.upper().split(' '):		# Capitalize all words and split on spaces
		word = indexRegex.sub('', word)			# Remove all characters not specified in indexRegex (any non-alphabetical characters)
		if len(word) > 2:						# Do not index any words with less than 3 characters
			if word not in search_index:		# Do not index duplicate words
				if word not in ignoredWords:	# Check against a list of ignored words
					search_index.append(word)	# Add word to index
					search_index = generate_wildcard(word, search_index)
	return search_index

def generate_wildcard(word, search_index):
	for x in range (0, len(word) + 1):
		search_index.append(word[:x] + '*' + word[x:])
	for x in range (0, len(word)):
		search_index.append(word[:x] + '*' + word[x+1:])
	return search_index

# VARIABLES (to be moved to a config file later)
# Database
username = 'Jimmy'
database = 'encrypted_search'
connString = 'localhost'
# Index
ignoredWords = []
ignoredWords.append('THE')
indexRegex = re.compile('[^a-zA-Z]')

# ROUTING
@route('/') # Homepage
@route('/index')
def index():
	# Get username from session
	username = 'Jimmy'
	btnLoginText = ''
	usernameColor = ''

	# If user is logged in, load username & styles; otherwise, display "Not logged in" message
	# Set login button text accordingly
	if username:
		btnLoginText = 'Logout'
		usernameColor = 'rgb(201, 229, 244)'
	else:
		username = 'Not logged in'
		btnLoginText = 'Login'
		usernameColor = 'rgb(255, 255, 255)'

	return template('index', username=username, btnLoginText=btnLoginText, usernameColor=usernameColor)

@route('/login', method="GET") # Login popup window
def index():
	return template('login', message='Login', messageStyle='', username='', usernameStyle='', password='', passwordStyle='')

@route('/login', method="POST") # Login popup window (after submitting "Login")
def index():
	authenticated = False	# Did the username and password match the database?
	un = '' 				# Will contain the username that's stored in the database
	pw = ''					# Will contain the password that's stored in the database
	email = ''				# Will contain the email that's stored in the database
	message = 'Login'		# The message displayed at the top of the screen (if login fails will contain an error message)
	usernameStyle = ''		# Style for the username textbox if that space is left blank
	passwordStyle = ''		# Style for the password textbox if that space is left blank
	if not request.POST['username']:	# If the username textbox is left blank, make the border bold and red
		usernameStyle = 'border: 2px solid rgb(255,100,100)'
	if not request.POST['password']:	# If the password textbox is left blank, make the border bold and red
		passwordStyle = 'border: 2px solid rgb(255,100,100)'

	if usernameStyle or passwordStyle:	# If either textbox is left blank apply the new style and reload the page, populating boxes with whatever was already entered before reloading
		return template('login', message=message, messageStyle='', username=request.POST['username'], usernameStyle=usernameStyle, password=request.POST['password'], passwordStyle=passwordStyle)

	# Open database connection
	con = MySQLdb.connect(connString)
	cur = con.cursor()
	cur.execute('USE {0}'.format(database))

	# Retrieve user information for the username entered
	cur.execute('SELECT * FROM users WHERE username="{0}"'.format(request.POST['username']))
	result = cur.fetchone()
	if result:
		un = result[0]
		pw = result[1]
		email = result[2]
	salt = hashlib.sha512(email[0:len(email)/2] + un[0:len(username)/2]).hexdigest()	# Generate the salt (formula: first half of the email + first half of the username)
	hashed_pw = hashlib.sha512(request.POST['password'] + salt).hexdigest()				# Hash the password and the salt together

	if request.POST['username'].lower() == un.lower():	# Check that the user entered the correct username
		if hashed_pw == pw:								# Check that the user entered the correct password
			authenticated = True						# User successfully logged in
		else:
			message = 'Invalid password'
	else:
		message = 'Username not found'

	# Close database connection
	cur.close()
	con.close()

	# If the login fails reload the page with the error message, otherwise store the username in the session and close the login window
	if authenticated:
		return template('login', message=message, messageStyle='color: rgb(255,100,100)', username=request.POST['username'], usernameStyle='', password=request.POST['password'], passwordStyle='')
	else:
		return template('index', username=un, btnLoginText='Logout', usernameColor='rgb(201, 229, 244)')

@route('/password_reset') # Reset Password popup window
def index():
	return template('password_reset')

@route('/create_account', method="GET") # Create Account popup window
def index():
	return template('create_account', message='Create Account', messageStyle='', username='', usernameStyle='', password='', passwordStyle='', email='', emailStyle='')

@route('/create_account', method="POST") # Create Account popup window (after submitting "Create Account")
def index():
	message = 'Create Account'				# The message displayed at the top of the screen (if login fails will contain an error message)
	username = request.POST['username']		# Username submitted by the user
	password = request.POST['password']		# Password submitted by the user
	email = request.POST['email']			# Email submitted by the user
	usernameStyle = ''						# Style for the username textbox if that space is left blank
	passwordStyle = ''						# Style for the password textbox if that space is left blank
	emailStyle = ''							# Style for the email textbox if that space is left blank

	salt = hashlib.sha512(email[0:len(email)/2] + username[0:len(username)/2]).hexdigest()	# Generate the salt (formula: first half of the email + first half of the username)
	hashed_password = hashlib.sha512(password + salt).hexdigest()							# Hash the password and the salt together

	if not request.POST['username']:		# If the username textbox is left blank, make the border bold and red
		usernameStyle = 'border: 2px solid rgb(255,100,100)'
	if not request.POST['password']:		# If the password textbox is left blank, make the border bold and red
		passwordStyle = 'border: 2px solid rgb(255,100,100)'
	if not request.POST['email']:			# If the email textbox is left blank, make the border bold and red
		emailStyle = 'border: 2px solid rgb(255,100,100)'

	if usernameStyle or passwordStyle or emailStyle:	# If any textbox is left blank apply the new style and reload the page, populating boxes with whatever was already entered before reloading
		return template('create_account', message=message, messageStyle='', username=request.POST['username'], usernameStyle=usernameStyle, password=request.POST['password'], passwordStyle=passwordStyle, email=request.POST['email'], emailStyle=emailStyle)

	# Open database connection
	con = MySQLdb.connect(connString)
	cur = con.cursor()
	cur.execute('USE {0}'.format(database))

	# Before creating a new user, make sure all information is unique
	cur.execute('SELECT COUNT(*) FROM users WHERE username="{0}"'.format(username))	# Check if the username already exists
	result = cur.fetchone()
	if result[0] > 0:
		message = 'Username already exists'
	else:
		cur.execute('SELECT COUNT(*) FROM users WHERE email="{0}"'.format(email))	# Check if the email already exists
		result = cur.fetchone()
		if result[0] > 0:
			message = 'Email already in use'
		else:
			cur.execute('INSERT INTO users (username, password, email) values("{0}","{1}","{2}")'.format(username, hashed_password, email)) # Insert new user into the database

	# Close database connection
	cur.close()
	con.close()

	# If the login fails reload the page with the error message, otherwise store the username in the session and close the login window
	if message != 'Create Account':
		return template('create_account', message=message, messageStyle='color: rgb(255,100,100)', username=request.POST['username'], usernameStyle='', password=request.POST['password'], passwordStyle='', email=request.POST['email'], emailStyle='')
	else:
		return template('index', username=username, btnLoginText='Logout', usernameColor='rgb(201, 229, 244)')

@route('/store', method="GET") # Store Documents popup window
def index():
	return template('store', subject='', body='', recipientsStyle='')

@route('/store', method="POST") # Store Documents popup window (after submitting "Submit")
def index():
	# Open database connection
	con = MySQLdb.connect(connString)
	cur = con.cursor()
	cur.execute('USE {0}'.format(database))

	sender = username 											# Set the "Sender" field equal to the user who is logged in
	recipients = request.POST['recipients']						# Email recipients
	subject = request.POST['subject']							# Email subject
	body = request.POST['body']									# Email body text
	fullText = '{0} {1} {2}'.format(recipients, subject, body) 	# Full text of all fields
	search_index = []											# Search index which is generated from the full text
	search_index = ' '.join(generate_search_index(fullText))	# Generate search index based on this project's algorithms and compile it into a string

	if recipients:	# Check that the user entered at least one recipient before storing the document in the database
		cur.execute('INSERT INTO documents (sender, recipients, subject, body, search_index, encrypted) values ("{0}","{1}","{2}","{3}","{4}", "{5}")'.format(sender, recipients, subject, body, search_index, 0))

	# Close database connection
	cur.close()
	con.close()

	# If the user did not leave the mandatory field (recipients) blank, reload the page and clear the text boxes; otherwise, make the recipients textbox border bold and red
	if recipients:
		return template('store', subject='', body='', recipientsStyle='')
	else:
		return template('store', subject=subject, body=body, recipientsStyle="border: 2px solid rgb(255, 100, 100)")

@route('/view', method="GET") # View Documents popup window
def index():
	documents = []	# Documents to display
	bodyTexts = []	# Body texts for documents

	# Open database connection
	con = MySQLdb.connect(connString)
	cur = con.cursor()
	cur.execute('USE {0}'.format(database))

	cur.execute('SELECT * FROM documents ORDER BY date_created DESC')	# Get all documents from the database
	for c in cur:							# 0 - ID; 1 - Sender; 2 - Recipients; 3 - Subject; 4 - Body; 5 - Search Index; 6 - Date Created
		documentId = c[0]					# Document ID
		sender = c[1]						# Email sender
		tmpRecipients = c[2].split(' ')		# Email recipients (stored as a string, split into a list); temp variable in case of multiple spaces
		subject = c[3]						# Email subject
		body = c[4]							# Email body
		timestamp = c[6]					# Email timestamp
		recipients = []						# Email recipients list

		# Loop through tmpRecipients and remove any empty slots in the list which would be created by the user entering multiple spaces
		for r in tmpRecipients:
			if r:
				recipients.append(r)

		# If the subject was left empty, display it as <No Subject>
		if re.match('^ *$', subject):
			subject = '<No Subject>'

		preSubject = ''						# Will be either "To [recipients]" or "From [sender]"
		if sender == username:				# If the current user is the sender, display as "To [recipient, ..., recipient]"
			preSubject = 'To ['
			i = 0
			for r in recipients:
				i += 1
				if i == len(recipients):
					preSubject += r
				else:
					preSubject += r + ', '
			preSubject += ']'
		elif username in recipients:		# If username is in the recipients of a different email, display as "From [sender]"
			preSubject = 'From [{0}]'.format(sender)

		# Only add the documents that pertain to the current user (i.e. they are either a sender or recipient)
		if username in recipients or sender == username:
			documents.append([str(documentId), '{0}: {1}'.format(preSubject, subject)])
			bodyTexts.append([str(documentId), '{0} on {1}\nSubject: {2}\n\n{3}'.format(preSubject, str(timestamp), subject, body)])

	# Close database connection
	cur.close()
	con.close()

	# Send documents and body texts to the template
	return template('view', documents=documents, bodyTexts=bodyTexts)

@route('/view', method="POST") # View Documents popup window (after submitting "Delete")
def index():
	documents = []										# Documents to display
	bodyTexts = []										# Body texts for documents
	selectedDocument = request.POST["documentList"]		# Document to delete

	# Open database connection
	con = MySQLdb.connect(connString)
	cur = con.cursor()
	cur.execute('USE {0}'.format(database))

	cur.execute('DELETE FROM documents WHERE id="{0}"'.format(selectedDocument))

	cur.execute('SELECT * FROM documents ORDER BY date_created DESC')	# Get all documents from the database
	for c in cur:							# 0 - ID; 1 - Sender; 2 - Recipients; 3 - Subject; 4 - Body; 5 - Search Index; 6 - Date Created
		documentId = c[0]					# Document ID
		sender = c[1]						# Email sender
		tmpRecipients = c[2].split(' ')		# Email recipients (stored as a string, split into a list); temp variable in case of multiple spaces
		subject = c[3]						# Email subject
		body = c[4]							# Email body
		timestamp = c[6]					# Email timestamp
		recipients = []						# Email recipients list

		# Loop through tmpRecipients and remove any empty slots in the list which would be created by the user entering multiple spaces
		for r in tmpRecipients:
			if r:
				recipients.append(r)

		# If the subject was left empty, display it as <No Subject>
		if re.match('^ *$', subject):
			subject = '<No Subject>'

		preSubject = ''						# Will be either "To [recipients]" or "From [sender]"
		if sender == username:				# If the current user is the sender, display as "To [recipient, ..., recipient]"
			preSubject = 'To ['
			i = 0
			for r in recipients:
				i += 1
				if i == len(recipients):
					preSubject += r
				else:
					preSubject += r + ', '
			preSubject += ']'
		elif username in recipients:		# If username is in the recipients of a different email, display as "From [sender]"
			preSubject = 'From [{0}]'.format(sender)

		# Only add the documents that pertain to the current user (i.e. they are either a sender or recipient)
		if username in recipients or sender == username:
			documents.append([str(documentId), '{0}: {1}'.format(preSubject, subject)])
			bodyTexts.append([str(documentId), '{0} on {1}\nSubject: {2}\n\n{3}'.format(preSubject, str(timestamp), subject, body)])

	# Close database connection
	cur.close()
	con.close()

	# Send documents and body texts to the template
	return template('view', documents=documents, bodyTexts=bodyTexts)


@route('/search', method="GET") # Search Documents popup window
def index():
	return template('search', documents='', bodyTexts='')

@route('/search', method="POST") # Search Documents popup window (after submitting "Search")
def index():
	documents = []													# Documents to display
	bodyTexts = []													# Body texts for documents
	searchTerms = generate_search_index(request.POST['search']) 	# User-submitted search terms
	returnAll = False												# Return all stored documents
	if searchTerms == []:											# If the user leaves the search field blank, return all stored documents
		returnAll = True

	# Open database connection
	con = MySQLdb.connect(connString)
	cur = con.cursor()
	cur.execute('USE {0}'.format(database))

	cur.execute('SELECT * FROM documents ORDER BY date_created DESC')	# Get all documents from the database
	for c in cur:							# 0 - ID; 1 - Sender; 2 - Recipients; 3 - Subject; 4 - Body; 5 - Search Index; 6 - Date Created
		documentId = c[0]					# Document ID
		sender = c[1]						# Email sender
		tmpRecipients = c[2].split(' ')		# Email recipients (stored as a string, split into a list); temp variable in case of multiple spaces
		subject = c[3]						# Email subject
		body = c[4]							# Email body
		searchIndex = c[5].split(' ')		# Email search index
		timestamp = c[6]					# Email timestamp
		recipients = []						# Email recipients list

		# Loop through tmpRecipients and remove any empty slots in the list which would be created by the user entering multiple spaces
		for r in tmpRecipients:
			if r:
				recipients.append(r)

		# If the subject was left empty, display it as <No Subject>
		if re.match('^ *$', subject):
			subject = '<No Subject>'

		preSubject = ''						# Will be either "To [recipients]" or "From [sender]"
		if sender == username:				# If the current user is the sender, display as "To [recipient, ..., recipient]"
			preSubject = 'To ['
			i = 0
			for r in recipients:
				i += 1
				if i == len(recipients):
					preSubject += r
				else:
					preSubject += r + ', '
			preSubject += ']'
		elif username in recipients:		# If username is in the recipients of a different email, display as "From [sender]"
			preSubject = 'From [{0}]'.format(sender)

		# Only add the documents that pertain to the current user (i.e. they are either a sender or recipient)
		if username in recipients or sender == username:
			keywordMatch = False # Was a search term found in the search index?
			# Check whether a search term is present in the search index; if so, append it to the list of documents to display
			# (If the user left the search field blank, return everything)
			if returnAll:
				keywordMatch = True
			else:
				for word in searchTerms:
					if word in searchIndex or not searchTerms:
						keywordMatch = True
			if keywordMatch:
				documents.append([str(documentId), '{0}: {1}'.format(preSubject, subject)])
				bodyTexts.append([str(documentId), '{0} on {1}\nSubject: {2}\n\n{3}'.format(preSubject, str(timestamp), subject, body)])

	# Close database connection
	cur.close()
	con.close()

	# Send documents and body texts to the template
	return template('search', documents=documents, bodyTexts=bodyTexts)

@route('/download_client') # Download Client popup window
def index():
	return template('download_client')

@route('/static/<filename>') # All static files (images, Javascript, CSS, etc.)
def send_static(filename):
    return static_file(filename, root='static')

# RUN
run(app=app, host='0.0.0.0', port=8080) # Listen for connections on port 8080
