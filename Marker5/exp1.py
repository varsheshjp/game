import numpy as np
from Hilbert import hilbert
# m=5
# n=2**m
# string="      "
# for i in range(0,n):
#     if(i>99):
#         string=string+str(i)+"   "
#     elif(i>9):
#         string=string+str(i)+"    "
#     else:
#         string=string+str(i)+"     "
# print(string)

# listmd=[[0,0] for i in range(0,n*n)]
# for i in range(0,n):
#     string=""
#     if(i>99):
#         string=string+str(i)+" : "
#     elif(i>9):
#         string=string+str(i)+"  : "
#     else:
#         string=string+str(i)+"   : "
#     for j in range(0,n):
#         md=xy2d(m,i,j)
#         listmd[md]=[i,j]
#         if(md>999):
#             string=string+str(md)+"  "
#         elif(md>99):
#             string=string+str(md)+"   "
#         elif(md>9):
#             string=string+str(md)+"    "
#         else:
#             string=string+str(md)+"     "
#     print(string)

s = 1024
side=s
x = np.arange(s * s).reshape(s, s)
listmd=list(hilbert(x))
space=2
margin=10
import tkinter as tk
from threading import Thread
def main():
    import tkinter as tk
    from threading import Thread
    scale = 2
    border = 10
    # we draw points in the order given. We assume the value of the array
    # is it's C style position in a contiguous 2d square array
    w = scale * side + 2 * border
    canvas = tk.Canvas(width=w, height=w)
    canvas.pack(expand=tk.YES, fill=tk.BOTH)
    canvas.create_window(w, w)
    def draw():
        for i in range(0,len(listmd)-1):
            canvas.create_line((listmd[i]%s)*space+margin, (listmd[i]//s)*space+margin,(listmd[i+1]%s)*space+margin, (listmd[i+1]//s)*space+margin)
    Thread(target=draw).start()
    tk.mainloop()  
if __name__ == '__main__':
    main()