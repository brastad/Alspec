import React, { useEffect, useState } from "react";
import { fetchJobs } from "../src/Jobs/api.js";
import { DataGrid } from "@mui/x-data-grid";
import "bootstrap/dist/css/bootstrap.min.css";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
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
      <div style={{ textAlign: "center" }}>
        <h1>Alspec Products</h1>

        <div>
          <Container>
            <Row>
              <Col style={{ border: "1px solid #000" }}>Job Id</Col>
              <Col style={{ border: "1px solid #000" }}>Job Title</Col>
              <Col style={{ border: "1px solid #000" }}>Job Description</Col>
            </Row>
          </Container>
        </div>
      </div>

      {jobs.length === 0 ? (
        <p>No jobs available.</p> // Handle empty data gracefully
      ) : (
        jobs.map((job) => <JobItem key={job.id} job={job} />)
      )}
    </div>
  );
};
const columns = [];
const rows = [];

const JobItem = ({ job }) => (
  // <div style={{ border: "1px solid #ccc", padding: "10px", margin: "10px 0" }}>

  <Container>
    <Row>
      <Col style={{ border: "1px solid #000" }}>{job.id}</Col>
      <Col style={{ border: "1px solid #000" }}>{job.title}</Col>
      <Col style={{ border: "1px solid #000" }}>{job.description}</Col>
    </Row>
    {/* </div> */}
    <Row style={{ border: "1px solid #000" }}>
      <Col sm></Col>
      <Col sm={8}>
        {job.subItems.map((sub) => (
          <Row
            style={{
              border: "1px solid #000",
              backgroundColor: getStatusColor(sub.status),
            }}
          >
            {" "}
            <Row>Item Id: {sub.itemId}</Row>
            <Row>Title: {sub.title}</Row>
            <Row>Description: {sub.description}</Row>
            <Row>Status: {sub.status}</Row>
            {/* <div key={sub.itemId} style={{ color: getStatusColor(sub.status) }}>
              <strong>{sub.title}:</strong> {sub.description} ({sub.status})
            </div> */}
          </Row>
        ))}
      </Col>
    </Row>
  </Container>
);

const getStatusColor = (status) => {
  switch (status) {
    case "Pending":
      return "orange";
    case "In Progress":
      return "yellow";
    case "Completed":
      return "green";
    default:
      return "white";
  }
};

export default JobList;
