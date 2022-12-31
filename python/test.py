import os
dataset = []
with os.scandir(
        "C:/Users/mrxst/Desktop/custom-object-detection-datasets-master/datasets/road-signs/MyImages/" + '24' + "/") as image:
            for entry in image:
                dataset.append(entry.name)
print(int(dataset[60][dataset[60].find('_', 6)+1:dataset[60].find('.')]))