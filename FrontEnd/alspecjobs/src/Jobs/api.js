export const fetchJobs = async () => {
  const response = await fetch("https://localhost:44319/api/jobs");
  const data = await response.json();
  return data;
};
