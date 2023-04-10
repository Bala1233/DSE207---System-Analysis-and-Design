function sortTable(n, SortBy) {
    //Parameter setting            
    // n      = Table Columns            
    // SortBy = Number  for Sort by Number            
    // SortBy != Number  for Srot By Alphabet                
    // //When those onclick funtion is sortTable get Clicking,  Run this function                
    var table, rows, switching, i, x, y, shouldswitch, dir, switchcount = 0;
    //table       = which table apply the sorting function            
    //rows        = which rows in the table            
    //switching   = true= start sorting data, false = sort complete, stop.            
    //i           = Control the loop            
    //x           = Current Rows            
    //y           = Next Rows            
    //shouldSwitch= Checking two rows, should be switching position or not            
    //dir         = Direction, sort Ascending or Descending            
    //switchcount = Control Direction is Asc or Desc     //Setting the table want to sort  as  <table id="MyTable">            
    table = document.getElementById("tableList");     //Start sorting           
    switching = true;     //Set the sorting direction to ascending:            
    dir = "asc";     //Make a loop that will continue until no switching has been done:            
    while (switching) {         // Let the loop wont sort again                
        switching = false;         // Declare the rows                
        rows = table.rows;         // Loop all the rows the table have                
        for (i = 1; i < (rows.length - 1); i++) {             // start by saying should be no switching any.                    
            shouldSwitch = false;             // n = Table Columns position                    
            x = rows[i].getElementsByTagName("TD")[n];
            y = rows[i + 1].getElementsByTagName("TD")[n];             // Sort By Number                    
            if (SortBy == Number) {                 //If the Text include alphabet, remove all                       
                let num1 = x.innerHTML.replace(/[^0-9\.]+/g, "");
                let num2 = y.innerHTML.replace(/[^0-9\.]+/g, "");
                // dir start by Ascending                  
                if (dir == "asc") {
                    if (Number(num1) > Number(num2)) {                         //Declare two rows, should be switching position                                
                        shouldSwitch = true; break;
                        //Stop The Loop                           
                    }
                }
                // sort by Descending                        
                else if (dir == "desc") {
                    if (Number(num1) < Number(num2)) {                         //Declare two rows, should be switching position                                
                        shouldSwitch = true; break;                                //Stop The Loop                       
                    }
                }
            }
            //Sort By Alphabet A-Z                    
            else {                        // dir start by Ascending                        
                if (dir == "asc") {
                    if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                        //Declare two rows, should be switching position                                
                        shouldSwitch = true; break;
                        //Stop The Loop                            
                    }
                } else if (dir == "desc") {
                    if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                        //Declare two rows, should be switching position                               
                        shouldSwitch = true; break;
                        //Stop The Loop                           
                    }
                }
            }
        }
        //For the Two Rows need to switch Position                
        if (shouldSwitch) {             //Switching Position                    
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);             //Complete Switch, set switching to true for continue the loop                   
            switching = true;             //increase count for check direction                   
            switchcount++;
        }
        //If Ascending, Two Rows no need to switch position               
        else {             // Count =0 meaning sort ascending failed                    
            if (switchcount == 0 && dir == "asc") {                 //Start Descending                        
                dir = "desc";                 //Continue Loop                        
                switching = true;
            }
        }
    }
}