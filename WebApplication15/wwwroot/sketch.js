let label2_v;
let label3_v;
let option_season;
let option_map;
let option_type;
let btn1;
let btn2;
let btn3;
let switch_00;
let switch_0;
let switch_1;
let switch_2;
var initImage;
let que_df;
let sel_x;
let sel_y;

var Sp;
var Sp2;
var We;
var We2;
var Olymp2;
var selected_map;
var selected_val;
var selected_inval;
var val_sp_18;
var val_sp_16;
var val_we_18;
var val_we_16;
var val_olym_18;

var inval_sp_18;
var inval_sp_16;
var inval_we_18;
var inval_we_16;
var inval_olym_18;

let calFrom;
let calFrom2;

let startFlag = 0;
let dfQues;
let totQues;
let gameNum;
let gameTime;
let count;
let correct;
let finishFlag;
let imgWidth;
let imgHeight;
let table;
let df_sel;
let factorx;
let factory;
let uniqueValues
let checkboxContainer;
let checkboxes = [];
let checkbox_all;


function preload() {
  // Load the image in the preload function
  initImage = loadImage("/Data/Imgs/SP.png");
  Sp = loadImage("/Data/Imgs/SP.png");
  Sp2 = loadImage("/Data/Imgs/SP2.png");
  We = loadImage("/Data/Imgs/WE.png");
  We2 = loadImage("/Data/Imgs/WE2.png");
  Olymp2 = loadImage("/Data/Imgs/Olympus2.png");
  val_sp_18 = loadImage("/Data/Imgs/ValidZones_SP_S18.png");
  val_sp_16 = loadImage("/Data/Imgs/ValidZones_SP_S16.png");
  val_we_18 = loadImage("/Data/Imgs/ValidZones_WE_S18.png");
  val_we_16 = loadImage("/Data/Imgs/ValidZones_WE_S16.png");
  val_olym_18 = loadImage("/Data/Imgs/ValidZones_Olympus_S18.png");
  
  inval_sp_18 = loadImage("/data/Imgs/InvalidZones_SP_S18.png");
  inval_sp_16 = loadImage("/data/Imgs/InvalidZones_SP_S16.png");
  inval_we_18 = loadImage("/data/Imgs/InvalidZones_WE_S18.png");
  inval_we_16 = loadImage("/data/Imgs/InvalidZones_WE_S16.png");
  inval_olym_18 = loadImage("/data/Imgs/InvalidZones_Olympus_S18.png");
  
  
  table = loadTable('/Circle.csv', 'csv', 'header');
}
function setup() {
  createCanvas(1920, 1080);
  background(30);
  uniqueValues = [];
  //createCanvas(1366, 560);
  //stroke(50);
  totQues = 0;
  label2_v = "You played 0 games and got 0 correct. Your win rate is 0%.";
  label3_v = "0/0";
  textSize(32);
  
  fill(255);
  textStyle(BOLD); // Set text style to bold
  text("Predict The Zone",800, 25)
  textSize(24);
  text(label2_v, 500, 50);
  
  /*fill(30);
  noStroke();
  rect(width * 0.15, height * 0.07, width * 0.52, height * 0.05);
  fill(255);
  label2_v="You played 20 games and got 16 correct. Your win rate is 75.42%";
  text(label2_v, width * 0.15, height * 0.1);
  //text("You played 20 games and got 16 correct. Your win rate is 75.42%", width * 0.15, height * 0.1);*/
  
  text("0/0",1400 ,50)
  
  
  text("Season",1590 ,100);
  option_season = createSelect();
  option_season.position(1700, 80);
  option_season.option("16");
  option_season.option("18");
  option_season.changed(updateFol);
  option_season.size(100, 30);
  
  text("Map",1590 ,170);
  option_map = createSelect();
  option_map.position(1700, 150);
  // Add map options dynamically from your data source
  option_map.option("SP");
  option_map.option("WE");
  option_map.option("Olympus");
  option_map.changed(updateFol);
  option_map.size(100,30);
  
  text("Type",1590 ,240);
  option_type = createSelect();
  option_type.position(1700, 220);
  option_type.option("1 Circle");
  option_type.option("2 Circles");
  option_type.selected("2 Circles");
  option_type.size(100,30);
  
  
  btn1 = createButton("Start");
  btn1.position(1650, 600);
  btn1.mousePressed(start);
  btn1.size(100,30);
  
  
  // btn2 = createButton("History");
  // btn2.position(1650, 670);
  // btn2.mousePressed(history);
  // btn2.size(100,30);
  
  btn3 = createButton("Stop");
  btn3.position(1650,660);
  btn3.mousePressed(close);
  btn3.size(100,30);
  
  
  text("From", 1600, 745);
  calFrom = createInput('', 'date');
  calFrom.position(1680,720);
  calFrom.size(120, 30);
  
  // Set initial date to today
  let today = new Date().toISOString().substr(0, 10);
  calFrom.attribute('value', "2015-02-10");
  
  
  text("To", 1610, 805);
  calFrom2 = createInput('', 'date');
  calFrom2.position(1680,780);
  calFrom2.size(120, 30);
  
  calFrom2.attribute('value', today);
  
  // Add label
  textAlign(CENTER, CENTER);
  textSize(16);
  
  switch_00 = createCheckbox("Center Method", false);
  switch_00.position(1650,840);
  //switch_00.changed(reconstruct);
  switch_00.size(200,30);
  switch_00.style('color', 'white');
  switch_00.style('background-color', 'rgb(30,30,30)');
  switch_00.style('font-size', '14px');
  
  switch_0 = createCheckbox("Triangle Method", false);
  switch_0.position(1650,900);
  //switch_0.changed(reconstruct);
  switch_0.size(200,30);
  switch_0.style('color', 'white');
  switch_0.style('background-color', 'rgb(30,30,30)');
  switch_0.style('font-size', '14px');
  
  switch_1 = createCheckbox("Valid Regions", false);
  switch_1.position(1650, 960);
  //switch_1.changed(reconstruct);
  switch_1.size(200,30);
  switch_1.style('color', 'white');
  switch_1.style('background-color', 'rgb(30,30,30)');
  switch_1.style('font-size', '14px');
  
  switch_2 = createCheckbox("Invalid Regions", false);
  switch_2.position(1650, 1020);
  //switch_2.changed(reconstruct);
  switch_2.size(200,30);
  switch_2.style('color', 'white');
  switch_2.style('background-color', 'rgb(30,30,30)');
  switch_2.style('font-size', '14px');
  
  //initImage = loadImage("/data/Imgs/SP.png", () => {
    image(initImage, 450, 58);
  selected_map = Sp;
  //print(initImage.width)
  //});
}

function draw() {
  // Draw anything specific to the canvas here if needed
}

function mousePressed() {
  // Handle mouse events here if needed
  
  if(mouseX>450 && mouseX<450+selected_map.width && mouseY>58 && mouseY<58+selected_map.height && totQues>0){
    //print(mouseX, mouseY);
    //circle(width * 0.03+que_df["arr"][14]*factorx,height * 0.12+que_df["arr"][15]*factory
    
    sel_x = mouseX;
    sel_y = mouseY;
    if(startFlag){
      eval();
    }
    else{
      next();
    }
  }
}
function filterColumnToTable(data, filterValue, filterValue2, newTable) {
  
  let selectedDate = calFrom.value();
  let selectedDate2 = calFrom2.value();
  for (let i = 0; i < data.getRowCount(); i++) {
        let value = data.getString(i, "season");
        let value2 = data.getString(i, "map");
        let value3 = data.getString(i, "TimeStamp");
        
        print("hhhhh",value3, selectedDate, selectedDate2);
        if (value === filterValue & value2===filterValue2 ) {
          let currentRow = data.getRow(i);
          let newRow = newTable.addRow();
      newRow.obj = Object.assign({}, currentRow.obj);
        }
      }
  print("fil2",newTable.legnth);
}

function createTableWithSameColumns(existingTable) {
  
    // Create a new table
    let newTable = new p5.Table();

    // Copy column names from the existing table
    let columnNames = existingTable.columns;
    
    // Add columns to the new table
    for (let i = 0; i < columnNames.length; i++) {
      newTable.addColumn(columnNames[i]);
    }

    return newTable;
}
  
function updateFol() {
  // Handle update for folders here if needed
  //print("updateFol");
  fill(30);
  noStroke();
  rect(1580, 270, 340, 320);
  fill(50);
  noStroke();
  rect(1580, 270, 240, 320);
  fill(255);
  strokeWeight(1);
  stroke(255);
  uniqueValues = [];
  //checkboxes = [];
  //checkboxes.splice(0, checkboxes.length);
  
  //checkboxes = [];
  let map = option_map.value();
  let season = option_season.value();
  //let type = option_type.value();

  let filteredTable = createTableWithSameColumns(table); //new p5.Table();

  // Filter data from the 'columnName' column
  //filterColumnToTable(table,season,map, filteredTable);
  filteredTable =filterData2(table, 'map', map, 'season', season);
  
  //print(map,season,"fil",filteredTable.getRowCount(), filteredTable.columns, filteredTable.getRow(2));
  
  //let filteredData = table.filter(row => row.map === map);
  //print("ttt", filteredData.getRowCount())
  
  uniqueValues = Array.from(new Set(filteredTable.getColumn("folder")));
  //print("555", uniqueValues.legnth)
  /*for (let i = 0; i < uniqueValues.length; i++) {
    print('Unique Value:', uniqueValues[i]);
  }*/
  try {
  checkboxContainer.remove();
    //print("remove")
  }
  catch(error){}
  checkboxContainer = createDiv('');
  checkboxContainer.position(1600, 280);
  checkboxContainer.size(230, 300); // Set the fixed size
  checkboxContainer.style('overflow', 'auto'); // Enable scrollbar
    checkbox_all = createCheckbox("Select All", false);
    checkbox_all.style('color', 'white');
  checkbox_all.style('background-color', 'rgb(30,30,30)');
  checkbox_all.style('font-size', '14px');
  checkbox_all.changed(sel_all);
  checkbox_all.size(200,30);
    checkbox_all.parent(checkboxContainer);
  // Create checkboxes
  for (let i = 0; i < uniqueValues.length; i++) {
    let checkbox = createCheckbox(uniqueValues[i], false);
    checkbox.size(200,30);
  checkbox.style('color', 'white');
  checkbox.style('background-color', 'rgb(30,30,30)');
  checkbox.style('font-size', '14px');
    checkbox.parent(checkboxContainer);
    checkboxes.push(checkbox);
  }
}
function sel_all(){
  if (checkbox_all.checked()){
    for (let i = 0; i < checkboxes.length; i++) {
    checkboxes[i].checked(true);
    }
    
  }
  else{
    for (let i = 0; i < checkboxes.length; i++) {
    checkboxes[i].checked(false);
    }
  }
}
function start() {
  // Handle start button press here
  //print("start", uniqueValues[0], uniqueValues.length)
  for (let i = 0; i < checkboxes.length; i++) {
  try {
  checkboxes[i].remove();
    //checkboxes.pop();
   // print("remove")
  }
  catch(error){}
  }
  //checkboxes = [];
  updateFol();
  fill(30);
  noStroke();
  rect(450, 58, 1020, 1025);
  fill(255);
  strokeWeight(1);
  stroke(255)
  finishFlag = 0;
  // Access and modify UI elements as needed
  // For example:
  // document.getElementById('btn1').disabled = true;
  // document.getElementById('btn3').disabled = false;
  correct = 0;
  count = 0;

  let map = option_map.value();
  let season = option_season.value();
  let type = option_type.value();
  
  //print(type);
  if (map === "") {
    alert("Please select map and folders");
    
    return;
  }

  // Load images based on map and season
  //let imagePath;
  if (map === "SP" && season === "16") {
    //imagePath = "/data/Imgs/SP.png"; // Adjust the actual paths accordingly
    image(Sp, 450, 58);
    imgWidth = Sp.width;
    imgHeight = Sp.height;
    selected_map = Sp;
    selected_val = val_sp_16;
    selected_inval = inval_sp_16;
    
  } else if (map === "SP" && season === "18") {
    //imagePath = "/data/Imgs/SP2.png";
    image(Sp2, 450, 58);
    imgWidth = Sp2.width;
    imgHeight = Sp2.height;
    selected_map = Sp2;
    selected_val = val_sp_18;
    selected_inval = inval_sp_18;
  } else if (map === "WE" && season === "16") {
    //imagePath = "/data/Imgs/WE.png";
    image(We, 450, 58);
    imgWidth = We.width;
    imgHeight = We.height;
    selected_map = We;
    selected_val = val_we_16;
    selected_inval = inval_we_16;
  } else if (map === "WE" && season === "18") {
    //imagePath = "/data/Imgs/WE2.png";
    image(We2, 450, 58);
    imgWidth = We2.width;
    imgHeight = We2.height;
    selected_map = We2;
    selected_val = val_we_18;
    selected_inval = inval_we_18;
  } else if (map === "Olympus" && season === "18") {
    //imagePath = "/data/Imgs/Olympus2.png";
    image(Olymp2, 450, 58);
    imgWidth = Olymp2.width;
    imgHeight = Olymp2.height;
    selected_map = Olymp2;
    selected_val = val_olym_18;
    selected_inval = inval_olym_18;
  } else if (map === "Olympus" && season === "16") {
    alert("No Olympus map in season 16");
    return;
  } else {
    alert("Please select map and folder");
    return;
  }
  factorx = width * 0.74/imgWidth;
  factory = height * 0.88/imgHeight 
  //initImage = loadImage(imagePath); 
  //image(initImage, width * 0.03, height * 0.12, width * 0.74, height * 0.88);
  startFlag = 1;
  df_sel = filterData(table, 'map', map, 'season', season);
  totQues = df_sel.length; 
  if(totQues>0){
  creatQues();
  }
  else{
    alert("no data for selected catogries");
  }
  

}

function filterData2(data, columnName, filterValue, columnName2, filterValue2) {
      //let filteredRows = [];
      let selectedDate = calFrom.value();
  let selectedDate2 = calFrom2.value();
      let filteredTable = createTableWithSameColumns(table); //new p5.Table();
  
  
  
  //print("start", uniqueValues[0], uniqueValues.length, filteredFolders.length, filteredFolders.includes("Northpad"));

      for (let i = 0; i < data.getRowCount(); i++) {
        let value = data.getString(i, columnName);
        let value2 = data.getString(i, columnName2);
        let value3 = data.getString(i, "TimeStamp");
        value3 = value3.replace(/_/g, "-");
        //print("hhh",value3.slice(0,10), selectedDate, selectedDate2, value3>=selectedDate);
        if (value === filterValue & value2===filterValue2) {
          let newRow = filteredTable.addRow();
          let currentRow = data.getRow(i);
          //newRow.set()
          newRow.obj = Object.assign({}, currentRow.obj);
          //newRow.arr = Array.assign({}, currentRow.arr);
          //filteredRows.push(data.getRow(i));
        }
      }
      //print("222",filteredRows.length, data.getRow(6), filteredTable.getRow(6) );
      // Return a new p5.Table with the filtered rows
      return filteredTable;
    }

function filterData(data, columnName, filterValue, columnName2, filterValue2) {
      let filteredRows = [];
      let filteredFolders = [];
  let selectedDate = calFrom.value();
  let selectedDate2 = calFrom2.value();
  
  
  
  
  for (let i = 0; i < checkboxes.length; i++) {
    if(checkboxes[i].checked()){
      //print(i);
      checkboxes[i].checked(false)
      filteredFolders.push(uniqueValues[i%uniqueValues.length]);
    }
    
    }
  //print("start", filteredFolders.length, filteredFolders, checkboxes.length);
  //checkboxes = [];

      for (let i = 0; i < data.getRowCount(); i++) {
        let value = data.getString(i, columnName);
        let value2 = data.getString(i, columnName2);
        let value3 = data.getString(i, "folder");
        let value4 = data.getString(i, "TimeStamp");
        value4 = value4.replace(/_/g, "-");
        value4 = value4.slice(0,10)
        //print("hhh",value4.slice(0,10), selectedDate, selectedDate2, value4>=selectedDate);
        //print(value3);
        if (value === filterValue & value2===filterValue2 & value4>=selectedDate & value4<=selectedDate2 &(filteredFolders.length===0 | filteredFolders.includes(value3))) {
          filteredRows.push(data.getRow(i));
        }
      }
     // print(filteredRows.length);
      // Return a new p5.Table with the filtered rows
      return filteredRows;//new p5.Table(filteredRows);
    }


function creatQues() {
  // Add the logic for creating questions
  // based on the provided Python code
  // ...
  //print(df_sel.length);
  startFlag = 1;
  image(selected_map, 450, 58);
  let randomInt = floor(random(0, df_sel.length));
  
  que_df = df_sel[randomInt];
  //print(df_sel[randomInt])
  df_sel.splice(randomInt, 1);
  //print(que_df["arr"][14],width * 0.03+que_df["arr"][14]*factorx);
  //print(que_df["arr"][15], height * 0.12+que_df["arr"][15]*factory);
  //print(que_df["arr"][17], width * 0.03+que_df["arr"][17]*factorx);
  //print(que_df["arr"][18], height * 0.12+que_df["arr"][18]*factory);
  noFill();
  stroke(255);
  strokeWeight(1);
  //image(Sp, width * 0.03, height * 0.12, width * 0.74, height * 0.88);
  //print("create", que_df["arr"][17], que_df["arr"][18], que_df["arr"][19])
  circle(450+int(que_df["arr"][17]),58+int(que_df["arr"][18]),int(que_df["arr"][19])*2);
  
  let type = option_type.value();
  if(type==="2 Circles"){
    circle(450+int(que_df["arr"][14]),58+int(que_df["arr"][15]),int(que_df["arr"][16])*2);
  }
  reconstruct();
  /*let testRows = [];
  testRows.push(1);
  testRows.push(2);
  testRows.push(3);
  testRows.push(4);
  testRows.push(5);
  print(testRows[1]);
  testRows.splice(1, 1);
  print(testRows);*/
}



function close() {
  // Handle stop button press here
}

function reconstruct() {
  // Handle checkbox changes for reconstruction here
  if(switch_00.checked()){
    fill(255,0,0);
    noStroke();
    
    let center_x = int(selected_map.width /2);
    let center_y = int(selected_map.height /2);
    
    circle(450+center_x, 58+center_y, 10);
    circle(450+int(que_df["arr"][17]),58+int(que_df["arr"][18]),10);

  circle(450+int(que_df["arr"][14]),58+int(que_df["arr"][15]),10);
  
  circle(450+int(que_df["arr"][11]),58+int(que_df["arr"][12]),10);
  
  circle(450+int(que_df["arr"][8]),58+int(que_df["arr"][9]),10);
  
  circle(450+int(que_df["arr"][5]),58+int(que_df["arr"][6]),10);
    
  //fill(0,255,0);
  strokeWeight(3);
  stroke(0,255,0);
  line(450+int(que_df["arr"][5]),58+int(que_df["arr"][6]),450+int(que_df["arr"][8]),58+int(que_df["arr"][9]));
  line(450+int(que_df["arr"][8]),58+int(que_df["arr"][9]),450+int(que_df["arr"][11]),58+int(que_df["arr"][12]));
  line(450+int(que_df["arr"][11]),58+int(que_df["arr"][12]),450+int(que_df["arr"][14]),58+int(que_df["arr"][15]));
  line(450+int(que_df["arr"][14]),58+int(que_df["arr"][15]),450+int(que_df["arr"][17]),58+int(que_df["arr"][18]));
  line(450+int(que_df["arr"][17]),58+int(que_df["arr"][18]),450+center_x, 58+center_y);
  }
  
  if(switch_0.checked()){
    let A_x = int(selected_map.width /2);
    let A_y = int(selected_map.height /2);
    let BA_x = A_x - int(que_df["arr"][17]);
    let BA_y = A_y - int(que_df["arr"][18]);
    let BA_unit_vector_x = BA_x/(BA_x**2+BA_y**2)**.5;
    let BA_unit_vector_y = BA_y/(BA_x**2+BA_y**2)**.5;
    let C_x = int(que_df["arr"][17]) + int(que_df["arr"][19]) * BA_unit_vector_x;
    let C_y = int(que_df["arr"][18]) + int(que_df["arr"][19]) * BA_unit_vector_y;
    
    let DB_x = int(que_df["arr"][17]) - int(que_df["arr"][14]);
    let DB_y = int(que_df["arr"][18]) - int(que_df["arr"][15]);
    
    let E_x = int(que_df["arr"][14]) - DB_x;
    let E_y = int(que_df["arr"][15]) - DB_y;
    
    let AC_x = C_x - A_x;
    let AC_y = C_y - A_y;
    let AC_unit_vector_x = AC_x/(AC_x**2+AC_y**2)**.5;
    let AC_unit_vector_y = AC_y/(AC_x**2+AC_y**2)**.5;
    
    let F_x = E_x + AC_x;
    let F_y = E_y + AC_y;
    
    let DF_x = F_x - int(que_df["arr"][14]);
    let DF_y = F_y - int(que_df["arr"][15]);
    let DE_x = E_x - int(que_df["arr"][14]);
    let DE_y = E_y - int(que_df["arr"][15]);
    
    let dot_product = F_x * E_x + F_y + E_y;
    let length_squared = E_x * E_x + E_y + E_y;
    
    let t = dot_product / length_squared
    
    let G_x = int(que_df["arr"][14]) + t * DE_x;
    let G_y = int(que_df["arr"][15]) + t * DE_y;
    
    strokeWeight(3);
    stroke(0,255,0);
    line(450+A_x, 58+A_y, 450+C_x, 58+C_y);
    stroke(205);
    line(450+A_x, 58+A_y, 450+int(que_df["arr"][14]), 58+int(que_df["arr"][15]));
    stroke(255,0,0);
    line(450+int(que_df["arr"][14]), 58+int(que_df["arr"][15]), 450+E_x, 58+E_y);
    stroke(0,0,255);
    line(450+E_x, 58+E_y,450+ F_x, 58+F_y);
    strokeWeight(2);
    stroke(0,255,255);
    line(450+F_x, 58+F_y, 450+G_x, 58+G_y);
    
    print(A_x, A_y, C_x, C_y, que_df["arr"][14], que_df["arr"][15], E_x, E_y, F_x, F_y, G_x, G_y);
    fill(255,0,0);
    noStroke();
    /*circle(450+AC_x, 58+AC_y, 10);
    circle(450+BD_x, 58+BD_y, 10);
    circle(450+DE_x, 58+DE_y, 10);
    circle(450+EF_x, 58+EF_y, 10);*/
    circle(450+A_x, 58+A_y, 10);
    circle(450+C_x, 58+C_y, 10);
    circle(450+E_x, 58+E_y, 10);
    circle(450+F_x, 58+F_y, 10);
    circle(450+int(que_df["arr"][14]), 58+int(que_df["arr"][15]), 10);
    circle(450+int(que_df["arr"][17]), 58+int(que_df["arr"][18]), 10);
    
    stroke(51, 255, 51);
    fill(51, 255, 51);
    textSize(18);
    text("A", 450+A_x+5, 58+A_y+5);
    text("B", 450+int(que_df["arr"][17])+5, 58+int(que_df["arr"][18])+5);
    text("C", 450+C_x+5, 58+C_y+5);
    text("D", 450+int(que_df["arr"][14])+5, 58+int(que_df["arr"][15])+5);
    text("E", 450+E_x+5, 58+E_y+5);
    text("F", 450+F_x+5, 58+F_y+5);
    
    
  }
  
  if(switch_1.checked()){
    //let val = 
    tint(255, 63);
    image(selected_val,450,58);
  }
  if(switch_2.checked()){
    tint(255, 63);
    image(selected_inval,450,58);
  }
  fill(255);
  strokeWeight(1);
  stroke(255);
  tint(255, 255);
  
}

function eval() {
  strokeWeight(1);
  noFill();
  //stroke(255);
  let out_text = "";
  //sel_x = width * 0.03+mouseX*factorx;
  if (((sel_x-(450+int(que_df["arr"][5])))**2+(sel_y-(58+int(que_df["arr"][6])))**2)**.5<= int(que_df["arr"][7]*2.1)){
    //print("Correct", ((sel_x-(450+que_df["arr"][5]))**2+(sel_y-(58+que_df["arr"][6]))**2)**.5, que_df["arr"][7]*2.1);
    stroke(255,0,0);
    stroke(0,255,0);
    out_text+= "Correct! , "
    correct+=1;

  
  
}
  else{
    //print("Wrong", sel_x, 450+int(que_df["arr"][5]),((sel_x-(450+int(que_df["arr"][5])))**2+(sel_y-(58+int(que_df["arr"][6])))**2)**.5, int(que_df["arr"][7])*2.1);
    stroke(255,0,0);
    out_text+= "Wrong! , "
  }
  
  circle(450+int(que_df["arr"][17]),58+int(que_df["arr"][18]),int(que_df["arr"][19])*2);

  circle(450+int(que_df["arr"][14]),58+int(que_df["arr"][15]),int(que_df["arr"][16])*2);
  
  circle(450+int(que_df["arr"][11]),58+int(que_df["arr"][12]),int(que_df["arr"][13])*2);
  
  circle(450+int(que_df["arr"][8]),58+int(que_df["arr"][9]),int(que_df["arr"][10])*2);
  
  circle(450+int(que_df["arr"][5]),58+int(que_df["arr"][6]),int(que_df["arr"][7])*2);
  
 stroke(255);
  circle(sel_x,sel_y, int(que_df["arr"][7])*2);
  startFlag = 0;
  count+=1;
  fill(30);
  noStroke();
  rect(500, 30, 1200, 28);
  fill(255);
  out_text += "You played " + count + " games and got " + correct + " correct. Your win rate is " + (100 * correct / count).toFixed(2) + "%.";
  textSize(24);
  text(out_text, 500, 50);
  let outtext2 = count + "/" + totQues
  text(outtext2, 1400, 50)
  
  //saveFrames('output', 'png', 1, 30);
  reconstruct();
}
  
  

function next() {
  if(count<totQues){
    creatQues();
  }
  else{
    finishFlag = 1;
    totQues = 0;
    alert("Congratulation!  You Have Finished All Images");
  }
}