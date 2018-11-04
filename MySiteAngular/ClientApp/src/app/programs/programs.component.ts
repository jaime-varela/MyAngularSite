import { Component, Inject } from '@angular/core';
import { Http, ResponseType } from '@angular/http';

@Component({
    selector: 'programs',
    templateUrl: './programs.component.html',
    styleUrls:['./programs.component.css']
})
export class ProgramsComponent {
    public ApiMetaData: ApiCallMetaData[];
    public ApiNames: string[];
    public currentProgram: ApiCallMetaData;
    public selectedOption : string;

    public RESULT : string;

    private isRunning : Boolean; 
    private baseURL : string;
    private apiCaller : Http;
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.selectedOption = "";
        this.RESULT = "results shown here.";
        this.ApiMetaData = [];
        this.ApiNames = [];
        this.isRunning = false;
        this.baseURL = baseUrl;
        this.apiCaller = http;
        this.currentProgram = {name:"",category:"",paramNames:[],description:"",endPoint:""};
        http.get(baseUrl + 'api/MetaData/All').subscribe(result => {
            this.ApiMetaData = result.json() as ApiCallMetaData[];
            this.ApiMetaData.forEach(x => { this.ApiNames.push(x.name)            
            });    
            this.ApiNames.sort();
        }, error => console.error(error));
    }

    public makeApiCall(){
        // Two things 1) should not run if api is still going
        // 2) make api call
        if(!this.isRunning)
        {
            this.isRunning = true;
            var query :string;
            query = this.baseURL + this.currentProgram.endPoint;
            console.log("here");
            for (let index = 0; index < this.currentProgram.paramNames.length; index++) {
                var doc = document.getElementById(this.currentProgram.paramNames[index]);
                if(doc != null)
                {
                    query += (<HTMLInputElement>doc).value; 
                    query += "/";
                }
            }
            console.log(query);
            this.apiCaller.get(query).subscribe(result => {
                this.RESULT = result.text() as string;
                this.isRunning = false;
            }, error => {console.error(error); this.RESULT = "invalid input or parameters out of computational range"; this.isRunning = false;});
        }
    }

    public loadForm(){    
        console.log("this.currentProgram.name")
        this.RESULT = "results shown here";  
        this.isRunning = false;  
        this.currentProgram = this.ApiMetaData.filter(x => x.name == this.selectedOption)[0];
    }    
}

interface ApiCallMetaData {
    category: string;
    name: string;
    paramNames: string[];
    description: string;
    endPoint: string;
}