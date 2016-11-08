rdslib.exe  "-ptype=inet,host=192.168.23.43" -o"127.0.0.1:c:\4rmd.gdb" -f"2079_retr.dat" -s0 -c30 -n500 -m00FD452E00FF102D -r102D  -D100 -a9A081f -M2  2>"2079_log.txt" 

            md %CD%\log\%date:~0,2%_%date:~3,2%_%date:~-4%
            
 move %CD%\2079_log.txt %CD%\log\%date:~0,2%_%date:~3,2%_%date:~-4% 