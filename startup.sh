#! /bin/bash

sudo service httpd start
sudo service mysqld start

./master.py