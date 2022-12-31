import os
from os import listdir

def renameImg(folder_dir, folder_dirDestination):
    with os.scandir(folder_dir) as image:
        for entry in image:
            imgId = int(entry.name[entry.name.find("_", 6) + 1:len(entry.name) - 4])
            imgMaskId = imgId - 87
            a = ""
            if (imgMaskId < 1000):
                if (imgMaskId >= 100):
                    a = "0"
                elif (imgMaskId >= 10):
                    a = "00"
                elif (imgMaskId >= 0):
                    a = "000"
            if (os.path.getsize(entry) / 1024 <= 10):
                os.replace(folder_dir + entry.name,
                           folder_dirDestination + entry.name[0:entry.name.find("_", 6) + 1] + a + str(
                               imgId - 87) + ".png")
def renameImgForDebug(folder_dir):
    with os.scandir(folder_dir) as image:
        for entry in image:
            imgId = int(entry.name[entry.name.find("_", 6) + 1:len(entry.name) - 4])
            imgMaskId = imgId + 43
            a = ""
            if (imgMaskId < 1000):
                if (imgMaskId >= 100):
                    a = "0"
                elif (imgMaskId >= 10):
                    a = "00"
                elif (imgMaskId >= 0):
                    a = "000"
            #if (os.path.getsize(entry) / 1024 <= 10):
            os.replace(folder_dir + entry.name,
                        folder_dir + entry.name[0:entry.name.find("_", 6) + 1] + a + str(
                            imgId + 43) + ".png")
def deleteExtraImages(folder_dir):
    lastImgId = 0
    i = 0
    with os.scandir(folder_dir) as image:
        for entry in image:
            imgId = int(entry.name[entry.name.find("_", 6) + 1:len(entry.name) - 4])
            if (abs(imgId - lastImgId) > 1):
                i = 0
                os.remove(folder_dir + entry.name)
            elif (i < 6):
                os.remove(folder_dir + entry.name)
            lastImgId = imgId
            i += 1
def deleteExtraMasks(folder_dir):
    lastImgId = 0
    i = 0
    with os.scandir(folder_dir) as image:
        for entry in image:
            imgId = int(entry.name[entry.name.find("_", 6) + 1:len(entry.name) - 4])
            if (abs(imgId - lastImgId) > 1):
                i = 0
                os.remove(folder_dirDestination + entry.name)
            elif (i < 6):
                os.remove(folder_dirDestination + entry.name)
            lastImgId = imgId
            i += 1

# get the path/directory
print("Folder To Sort: ")
choose = input()
folder_dir = "C:/Users/mrxst/Desktop/custom-object-detection-datasets-master/datasets/road-signs/MyImages/" + choose + "/"
folder_dirDestination = "C:/Users/mrxst/Desktop/custom-object-detection-datasets-master/datasets/road-signs/masks/" + choose + "/"
renameImg(folder_dir, folder_dirDestination)
images = sorted(os.scandir(folder_dir), key=lambda x: (x.is_dir(), int(x.name[x.name.find("_", 6)+1:len(x.name)-4])))
deleteExtraImages(folder_dir)
masks = sorted(os.scandir(folder_dirDestination), key=lambda x: (x.is_dir(), int(x.name[x.name.find("_", 6)+1:len(x.name)-4])))
deleteExtraMasks(folder_dirDestination)
#renameImgForDebug(folder_dir)