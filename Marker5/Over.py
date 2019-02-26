from Hilbert import d2xy
from Hilbert import xy2d
import cv2 as cv2
import numpy as np

m=8
n=2**m
d=[-1 for i in range(0,n*n)]
img = cv2.imread('test.jpg',0)
img=cv2.resize(img,(n,n))
k=0
pair=[]
for i in range(0,n):
    for j in range(0,n):
        d[xy2d(m,i,j)]=img[i][j]
        pair.append([i,j,xy2d(m,i,j)])
        k+=1
print(k)
d=np.array(d)
np.save("test.npy",d)
k=0
out=d
img2=np.empty((n,n),np.int32)
for i in range(0,len(pair)):
    img2[pair[i][0]][pair[i][1]]=out[pair[i][2]]
    print(pair[i][2],':',pair[i][0],",",pair[i][1],' - ',d2xy(m,pair[i][2]))
    k+=1
print(k)

cv2.imwrite("test2.jpg",img2)
img2=cv2.resize(img2,(n,n))
cv2.imshow("test2.jpg",img2)
cv2.waitKey()
print(img.shape)
print(img2.shape)