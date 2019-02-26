import math
from matplotlib import pyplot as plt
import numpy as np
listx=[]
listy=[]
listz=[]
listw=[]
phi=(1+5**(1/2))/2

def function(x):
    y=(phi**x)-(phi)
    return y
def function2(x):
    return (function4(x-1)*(phi**x))-(function4(x-2)*phi**(x-2))
def function4(x):
    return ((phi**i)-(-1*(phi-1))**i)/(5**(1/2))
x=float(input("last n"))
i=0
while i<x: 
    listx.append(i)
    listy.append(function(i))
    listz.append(function2(i))
    listw.append(function4(i))
    i=i+0.1

listx=np.array(listx)
listy=np.array(listy)
listz=np.array(listz)
listw=np.array(listw)
listz=(listy+phi)*math.log(phi)
plt.plot( listx,listy, color='skyblue')
plt.plot( listx,listz, color='black')
plt.plot( listx,listw, color='red')
#plt.plot(listx,,color="pink")
plt.legend()

plt.show()