/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package puzzle;

import java.util.Random;

/**
 *
 * @author varshesh
 */
class RandomListSelector{
    private int[] array;
    private int size;
    public RandomListSelector(int size){
        this.size=size;
        array=new int[this.size];
        for(int i=0;i<size;i++)
        {
            array[i]=i+1;
        }
    }
    public int getRandomNum(){
        Random rand = new Random();
        int randomindex=(rand.nextInt(1000)%this.size);
        int randomnum=array[randomindex];
        int i=0;
        while(randomindex>=i)
        {
            if(randomindex==i)
            {
                for(int j=i;j<size-1;j++)
                {
                    array[j]=array[j+1];
                }
                size=size-1;
            }
            i++;
        }
        return randomnum;
    }
}
class Puzzle {
        private int pj,pi;
        private int[][] array;
        private int arraysize;
        public Puzzle(int size)
        {
            this.arraysize=size;
            this.array =new int[this.arraysize][this.arraysize];
            this.setdata();
            this.setP();
        }
        public Puzzle(int[][] arr,int size)
        {
            this.arraysize=size;
            this.array =arr;
            this.setP();
        }
        public void setdata(){
                RandomListSelector ran=new RandomListSelector(arraysize*arraysize);
                for(int i=0;i<this.arraysize;i++)
                {
                    for(int j=0;j<this.arraysize;j++)
                    {
                        this.array[i][j]=ran.getRandomNum();
                    }
                }
        }
        public String getPrint(){
            String str;
            str="";
            for(int i=0;i<arraysize;i++){
                    int k=(arraysize*5);
                    
                    while(k>=0)
                    {
                        if(k%5==0)
                        {
                            str=str+" ";

                        }else{
                            str=str+" ";
                        }
                        k--;
                    }
                    str=str+"\n";
                    for(int j=0;j<arraysize;j++)
                    {

                        if(array[i][j]==arraysize*arraysize)
                        {
                            str=str+"|      ";
                        }
                        else{
                            if(array[i][j]>=10)
                            {
                                str=str+"| "+array[i][j]+" ";
                            }else
                            {
                                str=str+"|   "+array[i][j]+" ";
                            }
                        }
                    }
                    str=str+"|"+"\n";
              }
            int k=(arraysize*5);
            while(k>=0)
            {
                if(k%5==0)
                {
                    str=str+" ";

                }else{
                    str=str+" ";
                }
                k--;
            }
            str=str+"\n";
            return str;
        }
        public boolean swingCell(int key)
        {
            boolean flag=false;
            if(key==37){
                //left
                if((pj-1)<arraysize)
                {
                    if((pj-1)>=0){
                        swapcell(pi,pj-1,pi,pj);
                        pj=pj-1;
                        flag=true;
                    }
                }
            }
            else if(key==38){
                //up
                if((pi-1)<arraysize)
                {
                    if((pi-1)>=0){
                        swapcell(pi,pj,pi-1,pj);
                        pi=pi-1;
                        flag=true;
                    }
                }
            }
            else if(key==39){
                //right
                if((pj+1)<arraysize)
                {
                    if((pj+1)>=0){
                        swapcell(pi,pj+1,pi,pj);
                        pj=pj+1;
                        flag=true;
                    }
                }
            }
            else if(key==40){
                //down
                if((pi+1)<arraysize)
                {
                    if((pi+1)>=0){
                        swapcell(pi,pj,pi+1,pj);
                        pi=pi+1;
                        flag=true;
                    }
                }
            }
            else{}
            return flag;
        }
        public void swapcell(int x1,int y1,int x2,int y2)
        {
            int temp=array[x1][y1];
            array[x1][y1]=array[x2][y2];
            array[x2][y2]=temp;
        }
        public boolean check(){
            boolean ans=true;
            int k=1;
            for(int i=0;i<arraysize;i++)
            {
                for(int j=0;j<arraysize;j++)
                {
                    if(k!=array[i][j]){
                        ans=false;
                    }
                    k++;
                }
            }
            return ans;
        }
        public void setP()
        {
            for(int i=0;i<arraysize;i++)
            {
                for(int j=0;j<arraysize;j++)
                {if(array[i][j]==arraysize*arraysize){pi=i;pj=j;}}
            }
        }
}
