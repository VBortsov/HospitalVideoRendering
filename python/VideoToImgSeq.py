import cv2
vidcap = cv2.VideoCapture('Videos/IMG_0363.MOV')
success,image = vidcap.read()
count = 0
while success:
    if count < 10:
        a='000'
    if count < 100 and count >= 10:
        a = '00'
    if count < 1000 and count >= 100:
        a='0'
    cv2.imwrite("Images/25/image_005_" + a + "%d.png" % count, image)     
    success,image = vidcap.read()
    count += 1