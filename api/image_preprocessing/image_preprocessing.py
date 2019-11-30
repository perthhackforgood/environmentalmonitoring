import os, sys



def resize(image_blob):
    size = 224, 224
    try:
        im = Image.open(image_blob)
        im.thumbnail(size, Image.ANTIALIAS)
        # im.save(image_blob, "JPEG")
    except IOError:
        print("cannot create thumbnail for '%s'" % image_blob)
    return im

