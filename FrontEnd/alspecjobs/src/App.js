// import logo from './logo.svg';
// import './App.css';

// function App() {
//   return (
//     <div className="App">
//       <header className="App-header">
//         <img src={logo} className="App-logo" alt="logo" />
//         <p>
//           Edit <code>src/App.js</code> and save to reload.
//         </p>
//         <a
//           className="App-link"
//           href="https://reactjs.org"
//           target="_blank"
//           rel="noopener noreferrer"
//         >
//           Learn React
//         </a>
//       </header>
//     </div>
//   );
// }

// export default App;
// import axios, { AxiosResponse } from "axios";
// import {useEffect,useState} from "react";
// import {jobDto} from "./job.model";
// import {jobListUrl} from "./endPoints";
// export default function JobList() {
//   const [jobs, setjobs] = useState<jobDto[]>();
//   useEffect(() => {
//     axios.get(jobListUrl).then((response: AxiosResponse<jobDto[]>) => {
//       console.log(response.data);
//       setjobs(response.data);
//     })
//    },[]);
//     return(
//      <>
//      <table>
//       <thead>
//        <tr><th>Id</th>
//        <th>Title</th>
//        </tr>
//       </thead>
//       <tbody>
//        {jobs?.map((job)=>
//        (<tr key={job.id}><td>{job.id}</td><td>{job.Title}</td></tr>)}
//       </tbody>
//      </table>
//     ) => {
//       second;
//     };
//   }, [third]);
// }

// import axios, { AxiosResponse } from "axios";
// import {useEffect,useState} from "react";
// import {jobDto} from "./job.model";
// import {jobListUrl} from "./endPoints";
// export default function JobList() {
//   const [jobs, setjobs] = useState<jobDto[]>();
//   useEffect(() => {
//     axios.get(jobListUrl).then((response: AxiosResponse<jobDto[]>) => {
//       console.log(response.data);
//       setjobs(response.data);
//     })
//    },[]);
//     return(
//      <>
//      <table>
//       <thead>
//        <tr><th>Id</th>
//        <th>Title</th>
//        </tr>
//       </thead>
//       <tbody>
//        {jobs?.map((job)=>
//        (<tr key={job.id}><td>{job.id}</td><td>{job.Title}</td></tr>)}
//       </tbody>
//      </table>
//     ) => {
//       second;
//     };
//   }, [third]);
// }

import React, { useEffect, useState } from "react";
import { fetchJobs } from "../src/Jobs/api.js";
import { DataGrid } from "@mui/x-data-grid";

const JobList = () => {
  const [jobs, setJobs] = useState([]); // Store jobs fetched from the API
  const [loading, setLoading] = useState(true); // Track loading state
  const [error, setError] = useState(null); // Track errors during data fetching

  useEffect(() => {
    const getJobs = async () => {
      try {
        const data = await fetchJobs(); // Fetch data from the API
        setJobs(data);
      } catch (err) {
        setError("Failed to fetch jobs. Please try again later.");
      } finally {
        setLoading(false); // Stop loading once data is fetched or error occurs
      }
    };
    getJobs();
  }, []);

  if (loading) {
    return <p>Loading...</p>; // Show this while waiting for the API response
  }

  if (error) {
    return <p style={{ color: "red" }}>{error}</p>; // Show this if there's an error
  }

  return (
    <div>
      {/* <div style={{ height: 400, width: "100%" }}>
        <DataGrid rows={rows} columns={columns} />
      </div> */}
      <h1>Job Management</h1>
      {jobs.length === 0 ? (
        <p>No jobs available.</p> // Handle empty data gracefully
      ) : (
        jobs.map((job) => <JobItem key={job.id} job={job} />)
      )}
    </div>
  );
};
const columns = [
  { field: "id", headerName: "ID", width: 90 },
  { field: "title", headerName: "Title", width: 150 },
  { field: "description", headerName: "Description", width: 110 },
  { field: "status", headerName: "Status", width: 110 },
];

const rows = [];

<div></div>;
const JobItem = ({ job }) => (
  <div style={{ border: "1px solid #ccc", padding: "10px", margin: "10px 0" }}>
    <div className='row'>
      <div className='col'>Job Id</div>
      <h2>{job.id}</h2>
      <div className='col'>
        Job Title
        <h2>{job.title}</h2>
      </div>
      <div className='col'>
        Job Description
        <p>{job.description}</p>
      </div>
    </div>
    <div>
      {job.subItems.map((sub) => (
        <div key={sub.itemId} style={{ color: getStatusColor(sub.status) }}>
          <strong>{sub.title}:</strong> {sub.description} ({sub.status})
        </div>
      ))}
    </div>
    <ul>
      {job.subItems.map(
        (sub) =>
          rows.push({
            id: sub.itemId,
            name: sub.title,
            description: sub.description,
            status: sub.status,
          })
        // ,
        // (
        //   <li key={sub.itemId} style={{ color: getStatusColor(sub.status) }}>
        //     <strong>{sub.title}:</strong> {sub.description} ({sub.status})
        //   </li>
        // )
      )}
    </ul>
    <div style={{ height: 200, width: "100%" }}>
      <DataGrid rows={rows} columns={columns} />
    </div>
    ;
  </div>
);

const getStatusColor = (status) => {
  switch (status) {
    case "Pending":
      return "orange";
    case "In Progress":
      return "blue";
    case "Completed":
      return "green";
    default:
      return "black";
  }
};

export default JobList;
