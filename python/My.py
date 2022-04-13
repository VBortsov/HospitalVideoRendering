import numpy as np
import json
from pdb import set_trace as bp
from pathlib import Path
from tqdm import tqdm
from skimage import measure, io
from shapely.geometry import Polygon, MultiPolygon
from PIL import Image


def my_function(s, dataset):
    name = 'C:/Users/mrxst/Desktop/custom-object-detection-datasets-master/datasets/road-signs/masks/' + dataset + '/image_005_'
    name+=s
    im = Image.open(name)
    pixelMap = im.load()

    img = Image.new(im.mode, im.size)
    pixelsNew = img.load()

    for i in range(img.size[0]):
        for j in range(img.size[1]):
            if pixelMap[i, j][1] > 200:
                pixelMap[i, j] = (0, 255, 0)
            pixelsNew[i, j] = pixelMap[i, j]
    im.close()
    img.save(name)
    img.close()


def main():
    dataset = input()
    ImgStr = """
            "MyImages/""" + dataset + """21/image_005_"""
    MaskStr = """
            {
                "mask": "masks/""" + dataset + """/image_005_"""
    s = """
    {
        "masks":
        {
    """

    count = int(input())

    for i in range(count):
        a = ""
        s += ImgStr

        
        if i < 10:
            a+='000'
        if i < 100 and i >= 10:
            a += '00'
        if i < 1000 and i >= 100:
            a+='0'
        

        a+=str(i) + '.png'
        s+=a + '":'
        my_function(a, dataset)
        a = ""
        s+= MaskStr

        
        if i < 10:
            a='000'
        if i < 100 and i >= 10:
            a = '00'
        if i < 1000 and i >= 100:
            a='0'
        

        s+=a + str(i) + '.png",'
        a = ""
        s+="""
                "color_categories":
                {
                    "(0, 255, 0)": {"category": "patient", "super_category": "humans"}
                }
            },
        """
    a = ""
    s += ImgStr

    if count < 10:
        a+='000'
    if count < 100 and count >= 10:
        a += '00'
    if count < 1000 and count >= 100:
        a+='0'

    a += str(count) + '.png'
    s += a + '":'
    my_function(a, dataset)
    a = ""
    s+= MaskStr

    if count < 10:
        a='000'
    if count < 100 and count >= 10:
        a = '00'
    if count < 1000 and count >= 100:
        a='0'
    

    s+=a + str(count) + '.png",'
    a = ""
    s+="""
                "color_categories":
                {
                    "(0, 255, 0)": {"category": "patient", "super_category": "humans"}
                }
            }
        },
        """
    s+= """
        "super_categories":
        {
            "humans": ["patient"]
        }
    }
    """
    f = open('C:/Users/mrxst/Desktop/custom-object-detection-datasets-master/datasets/road-signs/mask_definitions.json', 'w')
    f.write(s)

main()
