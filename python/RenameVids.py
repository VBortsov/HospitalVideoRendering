import json

#jpath = input()
with open("annotations/instances_default23.json") as file:
    data = json.load(file)
count = 0
while count < len(data["images"]):
    if count < 10:
        a='000'
    if count < 100 and count >= 10:
        a = '00'
    if count < 1000 and count >= 100:
        a='0'
    data["images"][count]["file_name"] = "image_005_" + a + str(count) + ".png"     
    count += 1
with open("annotations/instances_default23.json", "w") as file:
    json.dump(data, file)
