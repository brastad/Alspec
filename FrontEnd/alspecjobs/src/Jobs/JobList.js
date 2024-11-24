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
import { fetchJobs } from "./api";

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
      <h1>Job Management</h1>
      {jobs.length === 0 ? (
        <p>No jobs available.</p> // Handle empty data gracefully
      ) : (
        jobs.map((job) => <JobItem key={job.id} job={job} />)
      )}
    </div>
  );
};

const JobItem = ({ job }) => (
  <div style={{ border: "1px solid #ccc", padding: "10px", margin: "10px 0" }}>
    <h2>{job.title}</h2>
    <p>{job.description}</p>
    <ul>
      {job.subItems.map((sub) => (
        <li key={sub.itemId} style={{ color: getStatusColor(sub.status) }}>
          <strong>{sub.title}:</strong> {sub.description} ({sub.status})
        </li>
      ))}
    </ul>
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
