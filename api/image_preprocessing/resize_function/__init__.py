import logging
import azure.functions as func
import io

from PIL import Image


def main(inputBlob: func.InputStream, outputBlob: func.Out[str]):

    logging.info(f"Blob trigger executed!")
    logging.info(f"Blob Name: {inputBlob.name} ({inputBlob.length}) bytes")
    logging.info(f"Full Blob URI: {inputBlob.uri}")

    img_data = inputBlob.read()

    img = Image.open(io.BytesIO(img_data))

    size = 224,224
    img.thumbnail(size, Image.ANTIALIAS)

    imgByteArr = io.BytesIO()
    img.save(imgByteArr, format='PNG')
    img = imgByteArr.getvalue()

    outputBlob.set(img)
