#!/bin/bash
#made by nathanmarley and HoseinHashemi
# absolute path to image folder
FOLDER="/root/Pictures/Declan" # current images folder
NEW="/root/Pictures/Take2" # resized images folder

# max height
WIDTH=540 #the height you want

# max width
HEIGHT=200 # the image you want

convert /root/Pictures/Declan/*.JPG -resize 540x200! /root/Pictures/Take2/newimages.jpg