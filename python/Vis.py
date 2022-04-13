from PIL import Image
import json

def my_function(s):
    name = 'C:/Users/mrxst/Desktop/custom-object-detection-datasets-master/datasets/road-signs/'
    name+=s
    im = Image.open(name)
    pixelMap = im.load()

    img = Image.new(im.mode, im.size)
    pixelsNew = img.load()

    for i in range(img.size[0]):
        for j in range(img.size[1]):
            if pixelMap[i, j][1] > 0:
                pixelMap[i, j] = (0, 255, 0, 255)
            pixelsNew[i, j] = pixelMap[i, j]
    im.close()
    img.show()
    img.save("out.tif")
    img.close()