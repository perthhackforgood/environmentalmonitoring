#!/bin/bash
# Purpose: batch image resizer to same folder
# Author: nathanmarley

# absolute path to image folder
FOLDER="/root/Pictures/Take2"

# the height
WIDTH=540

# the width
HEIGHT=300

#resize png or jpg to either height or width, keeps proportions using imagemagick
#find ${/root/Pictures/Declan} -iname '*.jpg' -o -iname '*.png' -exec convert \{} -verbose -resize $WIDTHx$HEIGHT\> \{} \;

#resize png to either height or width, keeps proportions using imagemagick
#find ${/root/Pictures/Declan} -iname '*.png' -exec convert \{} -verbose -resize $WIDTHx$HEIGHT\> \{} \;

#resize jpg only to either height or width, keeps proportions using imagemagick
find ${FOLDER} -iname '*.jpg' -exec convert \{} -verbose -resize $WIDTHx$HEIGHT\> \{} \;
#output ${NEW};


