import numpy as np
import json
import shutil
from pdb import set_trace as bp
from pathlib import Path
from tqdm import tqdm
from skimage import measure, io
from shapely.geometry import Polygon, MultiPolygon
from PIL import Image
import os
from os import listdir



FinalStr = ""

def my_function(dataset, videoNum, CurrentFrame):
    name = 'C:/Users/mrxst/Desktop/custom-object-detection-datasets-master/datasets/road-signs/masks/' + dataset + '/image_00' + videoNum + '_' + CurrentFrame
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

def main(datasetArr, videoNumArr, imgNumArr):
    s = """
{
    "masks":
    {
        """
    for idx in range(len(datasetArr)):
        dataset = datasetArr[idx]
        imgNum = imgNumArr[idx]
        ImgStr = """
        "MyImages/""" + dataset + """/image_00""" + imgNum + """_"""
        MaskStr = """
        {
            "mask": "masks/""" + dataset +"""/image_00""" + imgNum + """_"""
        counter = int(imgNum)
        for i in range(counter+1):
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
            my_function(dataset, videoNumArr, a)
            a = ""
            s+= MaskStr

            
            if i < 10:
                a='000'
            if i < 100 and i >= 10:
                a = '00'
            if i < 1000 and i >= 100:
                a='0'
            

            s+=a + str(i) + '.png",'
            s+="""
            "color_categories":
            {
                "(0, 255, 0)": {"category": "patient", "super_category": "humans"}
            }
        }"""
            if i < counter:
                s+= """,
                """
        if idx < len(datasetArr)-1:
            s+= """,
                """
        ImgStr = ""
        MaskStr = ""
    return s
datasetArr = []
videoNumArr = []
imgNumArr = []
while True:
    dataset = input()
    if dataset == "0":
        break
    videoNum = input()
    imgNum = str(len(os.listdir("C:/Users/mrxst/Desktop/custom-object-detection-datasets-master/datasets/road-signs/MyImages/" + dataset + "/")))
    datasetArr.append(dataset)
    videoNumArr.append(videoNum)
    imgNumArr.append(imgNum)
FinalStr = main(datasetArr, videoNumArr, imgNumArr)
FinalStr += """
    },

    "super_categories":
    {
        "humans": ["patient"]
    }
}
        """
f = open('C:/Users/mrxst/Desktop/custom-object-detection-datasets-master/datasets/road-signs/mask_definitions.json', 'w')
f.write(FinalStr)
